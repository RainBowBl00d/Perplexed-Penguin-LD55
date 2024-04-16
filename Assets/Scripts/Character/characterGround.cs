using UnityEngine;

//This script is used by both movement and jump to detect when the character is touching the ground

public class characterGround : MonoBehaviour
{
        private bool onGround;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == PlayerStats.instance.groundTag)
        {
            onGround = true;
        }
    }

    //Send ground detection to other scripts
    public bool GetOnGround() { return onGround; }
}