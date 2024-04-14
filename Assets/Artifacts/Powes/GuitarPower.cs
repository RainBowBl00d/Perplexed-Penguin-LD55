using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarPower : MonoBehaviour
{
    [SerializeField] float speed = 10f, acceleration = 4f;
    [SerializeField] float maxRange = 20f;
    [SerializeField] float minSpeed = 4f, maxSpeed = 20f;
    Vector2 mousePos;
    GameObject clone;
    Vector2 desiredDirection;
    Vector2 desiredForce;
    public void Power()
    {
        if (clone != null)
        {
            return;
        }
        clone = GameObject.Instantiate(gameObject,new Vector3( Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y , 0), Quaternion.identity);
        Rigidbody2D rb = clone.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }
    private void Update()
    {
        if (!gameObject.GetComponent<Rigidbody2D>())
        {
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position, mousePos, speed) ;

    }

}
