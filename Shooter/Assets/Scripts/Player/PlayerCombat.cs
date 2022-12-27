using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] Weapon[] weapons;
    [SerializeField] Animator animator;
    [SerializeField] UpdateAmmo updateAmmo;
    private int currentWeaponIndex = 0;
    public event Action<Weapon> AmmoAndBulletsChanged;

    private void Awake()
    {
        OnAmmoAndBulletsChanged(weapons[currentWeaponIndex]);
    }

    private void Start()
    {
        
    }

    public void ChangeWeaponUp()
    {
        if (currentWeaponIndex + 1 >= weapons.Length)
        {
            return;
        }
        else
        {
            currentWeaponIndex++;
        }
        animator.SetInteger("WeaponIndex", currentWeaponIndex);
        OnAmmoAndBulletsChanged(weapons[currentWeaponIndex]);
    }

    public void ChangeWeaponDown()
    {
        if (currentWeaponIndex <= 0)
        {
            return;
        }
        else
        {
            currentWeaponIndex--;
        }
        animator.SetInteger("WeaponIndex", currentWeaponIndex);
        OnAmmoAndBulletsChanged(weapons[currentWeaponIndex]);
    }

    private void OnAmmoAndBulletsChanged(Weapon currentWeapon)
    {
        AmmoAndBulletsChanged?.Invoke(currentWeapon);
    }

    public void TriggerWeapon(bool isShooting)
    {     
        if (isShooting)
        {
            weapons[currentWeaponIndex].Attack(animator);
            OnAmmoAndBulletsChanged(weapons[currentWeaponIndex]);
        }    
    }
}
