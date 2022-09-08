using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    private Rigidbody2D rb;
    private Vector2 direction;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();      
    }

    public void Move(Vector2 direction)
    {
        direction.Normalize();
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }
}
