using UnityEngine;

public class ViolinPower : MonoBehaviour
{
    GameObject player;
    GameObject clone;

    [Header("Attributes")]
    [SerializeField] float maxRange = 5f;
    [SerializeField] int damage = 10;
    [SerializeField] float smashSpeed = 10f;

    private void Start()
    {
    }
    public void Power()
    {
        if (clone != null)
        {
            return;
        }
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;

        float distance = Vector2.Distance(player.transform.position, Camera.main.ScreenToWorldPoint(mousePos));
        if (distance <= maxRange)
        {
            clone = Instantiate(gameObject);
            clone.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
            clone.transform.position = new(clone.transform.position.x, clone.transform.position.y, 0f);
            clone.GetComponent<Rigidbody2D>().gravityScale = 0f;
            clone.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -smashSpeed);

        }
        else
        {
            Vector2 vec = (Vector2)Camera.main.ScreenToWorldPoint(mousePos) - (Vector2)player.transform.position;
            vec = vec.normalized * maxRange;
            Vector2 pos = new(vec.x + player.transform.position.x, vec.y + player.transform.position.y);

            clone = Instantiate(gameObject, pos, Quaternion.identity);

            clone.GetComponent<Rigidbody2D>().gravityScale = 0f;
            clone.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -smashSpeed);
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
