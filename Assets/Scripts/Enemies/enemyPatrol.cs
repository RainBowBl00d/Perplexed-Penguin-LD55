using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyPatrol : MonoBehaviour
{
    private Rigidbody2D rb;
    //private Animator anim;
    private Vector2 direction;
    public float speed;
    int damage = 30;
    float timeLeft = 0f;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        direction = Vector2.right;
        //anim.SetBool("isRunning", true);

    }
    

    // Update is called once per frame
    void Update()
    {
        timeLeft += Time.deltaTime;
        rb.velocity = speed * direction;
        if (timeLeft > 5f)
        {
            timeLeft = 0f;
            direction = -direction;
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().SubtractHealt(damage);
            direction = -direction;
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        }
        else if(collision.tag == PlayerStats.instance.tag)
        {
            direction = -direction;
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        }

    }
}
