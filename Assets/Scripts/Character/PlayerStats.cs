using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    private void Awake()
    {
        instance = this;
    }

    [Header("Animation")]
    [SerializeField] public Animator myAnimator;

    [Header("Camera setting")]
    [SerializeField] public float yCameraOffset = 0f;
    [SerializeField] public float cameraLookAhead = 0f;
    [SerializeField] public float cameraMoveSpeed = 1f;
    [SerializeField, Range(0.01f, 15f)] public float ScreenSize = 10f;

    [Header("Movement Stats")]
    [SerializeField, Range(0f, 20f)] [Tooltip("Maximum movement speed")] public float maxSpeed = 10f;
    [SerializeField, Range(0f, 100f)] [Tooltip("How fast to reach max speed")] public float maxAcceleration = 52f;
    [SerializeField, Range(0f, 100f)] [Tooltip("How fast to stop after letting go")] public float maxDecceleration = 52f;
    [SerializeField, Range(0f, 100f)] [Tooltip("How fast to stop when changing direction")] public float maxTurnSpeed = 80f;
    [SerializeField, Range(0f, 100f)] [Tooltip("How fast to reach max speed when in mid-air")] public float maxAirAcceleration;
    [SerializeField, Range(0f, 100f)] [Tooltip("How fast to stop in mid-air when no direction is used")] public float maxAirDeceleration;
    [SerializeField, Range(0f, 100f)] [Tooltip("How fast to stop when changing direction when in mid-air")] public float maxAirTurnSpeed = 80f;
    [SerializeField] [Tooltip("Friction to apply against movement on stick")] public float friction;

    [Header("Jumping Stats")]
    [SerializeField, Range(2f, 5.5f)] [Tooltip("Maximum jump height")] public float jumpHeight = 7.3f;
    [SerializeField, Range(0.2f, 1.25f)] [Tooltip("How long it takes to reach that height before coming back down")] public float timeToJumpApex;
    [SerializeField, Range(0f, 5f)] [Tooltip("Gravity multiplier to apply when going up")] public float upwardMovementMultiplier = 1f;
    [SerializeField, Range(1f, 10f)] [Tooltip("Gravity multiplier to apply when coming down")] public float downwardMovementMultiplier = 6.17f;
    [SerializeField, Range(0, 1)] [Tooltip("How many times can you jump in the air?")] public int maxAirJumps = 0;

    [Header("Options")]
    [Tooltip("Should the character drop when you let go of jump?")] public bool variablejumpHeight;
    [SerializeField, Range(1f, 10f)] [Tooltip("Gravity multiplier when you let go of jump")] public float jumpCutOff;
    [SerializeField] [Tooltip("The fastest speed the character can fall")] public float speedLimit;
    [SerializeField, Range(0f, 0.3f)] [Tooltip("How long should coyote time last?")] public float coyoteTime = 0.15f;
    [SerializeField, Range(0f, 0.3f)] [Tooltip("How far from ground should we cache your jump?")] public float jumpBuffer = 0.15f;
    [Tooltip("When false, the charcter will skip acceleration and deceleration and instantly move and stop")] public bool useAcceleration;

    [Header("Tag")]
    public string groundTag;

    [Header("Current State")]
    public bool onGround;
    public bool pressingKey;
    public bool characterCanMove =  true;
    public bool canJumpAgain = false;
    public bool desiredJump;
    public float jumpBufferCounter;
    public float coyoteTimeCounter = 0;
    public bool pressingJump;
    public bool currentlyJumping;
    public bool squeezing;
    public bool jumpSqueezing;
    public bool landSqueezing;
    public bool playerGrounded;
    public Vector2 velocity;
}
