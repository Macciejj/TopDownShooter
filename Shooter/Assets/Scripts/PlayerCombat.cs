using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] Weapon[] weapons;
    [SerializeField] Animator animator;
    private int currentWeaponIndex = 0;


    public void ChangeWeapon()
    {
        if (currentWeaponIndex > weapons.Length)
        {
            currentWeaponIndex = 0;
        }
        else
        {
            currentWeaponIndex++;
        }
        animator.SetInteger("WeaponIndex", currentWeaponIndex);
    }
    public void TriggerWeapon(bool isShooting)
    {     
        if (isShooting)
        {
            weapons[currentWeaponIndex].Shoot(animator);

        }    
    }
}
