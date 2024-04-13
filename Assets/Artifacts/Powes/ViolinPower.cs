using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViolinPower : MonoBehaviour
{
    [SerializeField] GameObject player;
    GameObject clone;

    [Header("Attributes")]
    [SerializeField]float maxRange = 5f;
    [SerializeField] int damage = 10;
    [SerializeField] float smashSpeed = 10f;
    public void Power()
    {
        if (gameObject != null)
        {
            return;
        }
        float distance = Vector2.Distance(player.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (distance <= maxRange)
        {
            clone = Instantiate(gameObject);
            clone.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D cClone = clone.GetComponent<Collider2D>();
            Rigidbody2D rbClone = clone.AddComponent<Rigidbody2D>();
            rbClone.gravityScale = 0f;
            rbClone.velocity = new(0f, -smashSpeed);
        }
        else
        {
            Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
            vec = Vector2.ClampMagnitude(vec, maxRange);
            Vector2 pos = new(vec.x + player.transform.position.x, vec.y + player.transform.position.y);

            clone = Instantiate(gameObject);
            clone.transform.position = pos ;
            Collider2D cClone = clone.GetComponent<Collider2D>();
            cClone.isTrigger = true;
            Rigidbody2D rbClone = clone.AddComponent<Rigidbody2D>();
            rbClone.gravityScale = 0f;
            rbClone.velocity = new(0f, -smashSpeed);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Health>().SubtractHealt(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
