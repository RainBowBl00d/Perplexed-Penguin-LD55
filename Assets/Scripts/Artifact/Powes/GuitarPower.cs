using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarPower : MonoBehaviour
{
    [SerializeField] float speed = 10f, acceleration = 4f;
    [SerializeField] float maxRange = 20f, summonTime = 15;
    [SerializeField] float minSpeed = 4f, maxSpeed = 20f;
    Vector3 mousePos;
    GameObject clone;
    float timeleft = 0;

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
        timeleft += Time.deltaTime;
        if(timeleft >= summonTime)
        {
            Destroy(gameObject);
        }
        if (!gameObject.GetComponent<Rigidbody2D>())
        {
            return;
        }
        mousePos = Input.mousePosition;
        mousePos = new Vector3 (mousePos.x, mousePos.y, 10f);
        Vector3 wMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = Vector2.MoveTowards(transform.position, wMousePos, speed) ;

    }

}
