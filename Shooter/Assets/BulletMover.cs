using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] float Speed = 100;
    private Vector3 direction;
    private void Awake()
    {
        direction = transform.up;
        direction.Normalize();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * Speed;
    }
}
