using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, Controls.IPlayerActions
{
    [SerializeField] Animator animator;

    private PlayerCombat playerShooter;
    private bool isShooting = false;
    private Controls inputActions;
    private Vector2 direction;
    private Mover mover;

    private void Awake()
    {
        playerShooter = GetComponent<PlayerCombat>();
        mover = GetComponent<Mover>();
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

    private void Update()
    {
        playerShooter.Shoot(animator, isShooting);
    }

    private void FixedUpdate()
    {
        mover.Move(direction);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        direction = new Vector2(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y);
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
