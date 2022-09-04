using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] Animator animator;
    [SerializeField] [Range(0, 2)] int weaponType;
    void Start()
    {
        
    }

    void Update()
    {
        Move();
        LookAtMouse();
        ChangeWeapon();
        Attack();
        
    }

    private void ChangeWeapon()
    {
        animator.SetInteger("WeaponIndex", weaponType);
    }

    private void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(x * Time.deltaTime * speed, y * Time.deltaTime * speed, 0);
    }

    private void LookAtMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - transform.position;
        direction.Normalize();
        transform.up = direction;
    }
}
