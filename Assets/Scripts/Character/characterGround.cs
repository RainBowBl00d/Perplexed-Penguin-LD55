using System;
using Unity.VisualScripting;
using UnityEngine;

//This script is used by both movement and jump to detect when the character is touching the ground

public class characterGround : MonoBehaviour
{
        private bool onGround;
       
        [Header("Collider Settings")]
        [SerializeField][Tooltip("Length of the ground-checking collider")] private float groundLength = 0.95f;
        [SerializeField][Tooltip("Distance between the ground-checking colliders")] private Vector3 colliderOffset;

        [Header("Layer Masks")]
        [SerializeField][Tooltip("Which layers are read as the ground")] private LayerMask groundLayer;

        private void OnTriggerEnter2D(Collider2D other)
        {
                if (other.tag=="Ground" || other.tag=="Enemy")
                {
                        onGround = true;
                }
        }
        

        private void OnTriggerExit2D(Collider2D other)
        {
                if (other.tag == "Ground" || other.tag == "Enemy")
        {
                        onGround = false;
                }
        }
        
        //Send ground detection to other scripts
        public bool GetOnGround() { return onGround; }
}