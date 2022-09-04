using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, Controls.IPlayerActions
{
    [SerializeField] float speed = 10;
    [SerializeField] Animator animator;
    [SerializeField] [Range(0, 2)] int weaponType;
    [SerializeField] Transform rifflePosition;
    [SerializeField] GameObject bullet;
    Controls inputActions;
    Vector2 direction;

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
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(direction.x * Time.deltaTime * speed, direction.y * Time.deltaTime * speed, 0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        direction = new Vector2(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y);
        direction.Normalize();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            animator.SetTrigger("Attack");
            Quaternion rotation = transform.rotation;
            Instantiate(bullet, rifflePosition.position, rotation);
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
        print(context.ReadValue<float>());

        if(context.ReadValue<float>() == 0f)
        {
            if (weaponType >= 2)
            {
                weaponType = 0;
            }
            else
            {
                weaponType++;
            }
            animator.SetInteger("WeaponIndex", weaponType);
        }
        
    }
}
