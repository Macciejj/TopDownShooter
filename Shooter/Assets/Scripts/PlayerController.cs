using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, Controls.IPlayerActions
{
    [SerializeField] float speed = 10;
    [SerializeField] Animator animator;

    PlayerShooter playerShooter;
    bool isShooting = false;
    Controls inputActions;
    Vector2 direction;

    private void Awake()
    {
        playerShooter = GetComponent<PlayerShooter>();
    }

    private void OnEnable()
    {
        inputActions = new Controls();
        inputActions.Player.SetCallbacks(this);
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
       playerShooter.Shoot(animator, isShooting);
    }

    private void Move()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x *  speed, direction.y * speed);
        //transform.position += new Vector3(direction.x * Time.deltaTime * speed, direction.y * Time.deltaTime * speed, 0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        direction = new Vector2(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y);
        direction.Normalize();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            isShooting = true;
        }
        if(context.canceled)
        {
            isShooting = false;
        }
        
    }

    public void OnTurn(InputAction.CallbackContext context)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        Vector2 direction = mousePosition - transform.position;
        direction.Normalize();
        transform.up = direction;
    }

    public void OnChangeWeapon(InputAction.CallbackContext context)
    {
        if(context.ReadValue<float>() == 0f)
        {
            playerShooter.ChangeWeapon(animator);
        }
        
    }
}
