using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();      
    }

    public void Move(Vector2 direction)
    {
        direction.Normalize();
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }

    public void Turn(Vector2 mouseScreenPosition)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        Vector2 direction = mousePosition - transform.position;
        direction.Normalize();
        transform.up = direction;
    }
}
