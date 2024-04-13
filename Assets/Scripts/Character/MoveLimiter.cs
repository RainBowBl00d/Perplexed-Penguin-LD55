using UnityEngine;

public class MoveLimiter : MonoBehaviour
{
    private BoxCollider2D ground;
    [HideInInspector]public bool isGrounded = true;
    
    void Start()
    {
        ground = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
