using UnityEngine;
using UnityEngine.InputSystem;

//This script handles moving the character on the Y axis, for jumping and gravity

public class characterJump : MonoBehaviour
{
    private Rigidbody2D body;
    private characterGround ground;
    private characterJuice juice;

    [Header("Calculations")]
    public float jumpSpeed;
    public Vector2 velocity;
    private float defaultGravityScale;
    public float gravMultiplier;


    void Awake()
    {
        //Find the character's Rigidbody and ground detection and juice scripts

        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<characterGround>();
        juice = GetComponentInChildren<characterJuice>();
        defaultGravityScale = 1f;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("Jumping");
        if (PlayerStats.instance.characterCanMove)
        {
            if (context.started)
            {
                PlayerStats.instance.desiredJump = true;
                PlayerStats.instance.pressingJump = true;
            }

            if (context.canceled)
            {
                PlayerStats.instance.pressingJump = false;
            }
        }
    }

    void Update()
    {
        setPhysics();

        //Check if we're on ground, using Kit's Ground script
        PlayerStats.instance.onGround = ground.GetOnGround();

        //Jump buffer allows us to queue up a jump, which will play when we next hit the ground
        if (PlayerStats.instance.jumpBuffer > 0)
        {
            //Instead of immediately turning off "desireJump", start counting up...
            //All the while, the DoAJump function will repeatedly be fired off
            if (PlayerStats.instance.desiredJump)
            {
                PlayerStats.instance.jumpBufferCounter += Time.deltaTime;

                if (PlayerStats.instance.jumpBufferCounter > PlayerStats.instance.jumpBuffer)
                {
                    //If time exceeds the jump buffer, turn off "desireJump"
                    PlayerStats.instance.desiredJump = false;
                    PlayerStats.instance.jumpBufferCounter = 0;
                }
            }
        }

        //If we're not on the ground and we're not currently jumping, that means we've stepped off the edge of a platform.
        //So, start the coyote time counter...
        if (!PlayerStats.instance.currentlyJumping && !PlayerStats.instance.onGround)
        {
            PlayerStats.instance.coyoteTimeCounter += Time.deltaTime;
        }
        else
        {
            //Reset it when we touch the ground, or jump
            PlayerStats.instance.coyoteTimeCounter = 0;
        }
    }

    private void setPhysics()
    {
        //Determine the character's gravity scale, using the stats provided. Multiply it by a gravMultiplier, used later
        Vector2 newGravity = new Vector2(0, (-2 * PlayerStats.instance.jumpHeight) / (PlayerStats.instance.timeToJumpApex * PlayerStats.instance.timeToJumpApex));
        body.gravityScale = (newGravity.y / Physics2D.gravity.y) * gravMultiplier;
    }

    private void FixedUpdate()
    {
        //Get velocity from Kit's Rigidbody 
        velocity = body.velocity;

        //Keep trying to do a jump, for as long as desiredJump is true
        if (PlayerStats.instance.desiredJump)
        {
            DoAJump();
            body.velocity = velocity;

            //Skip gravity calculations this frame, so currentlyJumping doesn't turn off
            //This makes sure you can't do the coyote time double jump bug
            return;
        }

        calculateGravity();
    }

    private void calculateGravity()
    {
        //We change the character's gravity based on her Y direction

        //If Kit is going up...
        if (body.velocity.y > 0.01f)
        {
            if (PlayerStats.instance.onGround)
            {
                //Don't change it if Kit is stood on something (such as a moving platform)
                gravMultiplier = defaultGravityScale;
            }
            else
            {
                //If we're using variable jump height...)
                if (PlayerStats.instance.variablejumpHeight)
                {
                    //Apply upward multiplier if player is rising and holding jump
                    if (PlayerStats.instance.pressingJump && PlayerStats.instance.currentlyJumping)
                    {
                        gravMultiplier = PlayerStats.instance.upwardMovementMultiplier;
                    }
                    //But apply a special downward multiplier if the player lets go of jump
                    else
                    {
                        gravMultiplier = PlayerStats.instance.jumpCutOff;
                    }
                }
                else
                {
                    gravMultiplier = PlayerStats.instance.upwardMovementMultiplier;
                }
            }
        }

        //Else if going down...
        else if (body.velocity.y < -0.01f)
        {

            if (PlayerStats.instance.onGround)
            //Don't change it if Kit is stood on something (such as a moving platform)
            {
                gravMultiplier = defaultGravityScale;
            }
            else
            {
                //Otherwise, apply the downward gravity multiplier as Kit comes back to Earth
                gravMultiplier = PlayerStats.instance.downwardMovementMultiplier;
            }

        }
        //Else not moving vertically at all
        else
        {
            if (PlayerStats.instance.onGround)
            {
                PlayerStats.instance.currentlyJumping = false;
            }

            gravMultiplier = defaultGravityScale;
        }

        //Set the character's Rigidbody's velocity
        //But clamp the Y variable within the bounds of the speed limit, for the terminal velocity assist option
        body.velocity = new Vector3(velocity.x, Mathf.Clamp(velocity.y, -PlayerStats.instance.speedLimit, 100));
    }

    private void DoAJump()
    {

        //Create the jump, provided we are on the ground, in coyote time, or have a double jump available
        if (PlayerStats.instance.onGround || (PlayerStats.instance.coyoteTimeCounter > 0.03f && PlayerStats.instance.coyoteTimeCounter < PlayerStats.instance.coyoteTime) || PlayerStats.instance.canJumpAgain)
        {
            PlayerStats.instance.desiredJump = false;
            PlayerStats.instance.jumpBufferCounter = 0;
            PlayerStats.instance.coyoteTimeCounter = 0;

            //If we have double jump on, allow us to jump again (but only once)
            PlayerStats.instance.canJumpAgain = (PlayerStats.instance.maxAirJumps == 1 && PlayerStats.instance.canJumpAgain == false);

            //Determine the power of the jump, based on our gravity and stats
            jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * body.gravityScale * PlayerStats.instance.jumpHeight);

            //If Kit is moving up or down when she jumps (such as when doing a double jump), change the jumpSpeed;
            //This will ensure the jump is the exact same strength, no matter your velocity.
            if (velocity.y > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
            }
            else if (velocity.y < 0f)
            {
                jumpSpeed += Mathf.Abs(body.velocity.y);
            }

            //Apply the new jumpSpeed to the velocity. It will be sent to the Rigidbody in FixedUpdate;
            velocity.y += jumpSpeed;
            PlayerStats.instance.currentlyJumping = true;

            if (juice != null)
            {
                //Apply the jumping effects on the juice script
                juice.jumpEffects();
            }
        }

        if (PlayerStats.instance.jumpBuffer == 0)
        {
            //If we don't have a jump buffer, then turn off desiredJump immediately after hitting jumping
            PlayerStats.instance.desiredJump = false;
        }
    }

    public void bounceUp(float bounceAmount)
    {
        //Used by the springy pad
        body.AddForce(Vector2.up * bounceAmount, ForceMode2D.Impulse);
    }
}