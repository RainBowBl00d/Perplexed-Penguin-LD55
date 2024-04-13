using UnityEngine;

public class ViolinPower : MonoBehaviour
{
    [SerializeField] GameObject player;
    GameObject clone;

    [Header("Attributes")]
    [SerializeField] float maxRange = 5f;
    [SerializeField] int damage = 10;
    [SerializeField] float smashSpeed = 10f;

    public void Power()
    {
        if (clone != null)
        {
            return;
        }

        float distance = Vector2.Distance(player.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Debug.Log(distance);
        Debug.Log(maxRange);
        if (distance <= maxRange)
        {
            clone = Instantiate(gameObject);

            clone.transform.position = new(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f) ;

            Rigidbody2D rbClone = clone.AddComponent<Rigidbody2D>();

            rbClone.gravityScale = 0f;
            rbClone.velocity = new Vector2(0f, -smashSpeed);
        }
        else
        {
            Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
            vec = Vector2.ClampMagnitude(vec, maxRange);
            Vector2 pos = new(vec.x + player.transform.position.x, vec.y + player.transform.position.y);

            clone = Instantiate(gameObject);
            clone.transform.position = pos;

            Rigidbody2D rbClone = clone.AddComponent<Rigidbody2D>();
            rbClone.gravityScale = 0f;
            rbClone.velocity = new Vector2(0f, -smashSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().SubtractHealt(damage);
            Destroy(gameObject);
        }
        else if (collision.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
