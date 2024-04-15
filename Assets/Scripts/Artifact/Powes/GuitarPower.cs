using UnityEngine.InputSystem;
using UnityEngine;

public class GuitarPower : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float maxRange = 20f;
    [SerializeField] float radius = 20f;
    [SerializeField] int damage = 10;

    Vector3 mousePos;
    GameObject clone;
    float timeleft = 0;
    bool canSummon = true;

    public void Power()
    {
        Vector2 startPos = Random.insideUnitCircle.normalized * radius;
        clone = Instantiate(gameObject,(Vector3)startPos, Quaternion.identity);
        Rigidbody2D rb = clone.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        mousePos = Mouse.current.position.ReadValue();
        mousePos = new Vector3(mousePos.x, mousePos.y, 10f);
        Vector3 wMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        
        Vector2 desiredDirection = (Vector2)wMousePos - startPos;
        rb.AddForce(desiredDirection * speed);
    }
    private void Update()
    {
        timeleft += Time.deltaTime;
        if (!GetComponent<Rigidbody2D>())
        {
            return;
        }
        if (timeleft > 10f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == PlayerStats.instance.groundTag)
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == PlayerStats.instance.enemyTag)
        {
            collision.gameObject.GetComponent<Health>().SubtractHealt(damage);
            Destroy(gameObject);
        }
    }
}
