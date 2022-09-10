using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] Weapon[] weapons;
    int currentWeaponIndex = 0;
    float lastShot = Mathf.Infinity;
    Stopwatch stopwatch;

    private void Start()
    {
        stopwatch = new Stopwatch();
    }

    public void ChangeWeapon(Animator animator)
    {
        if (currentWeaponIndex >= 2)
        {
            currentWeaponIndex = 0;
        }
        else
        {
            currentWeaponIndex++;
        }
        animator.SetInteger("WeaponIndex", currentWeaponIndex);
    }
    public void Shoot(Animator animator, bool isShooting)
    {     
        if (isShooting)
        {
            if (lastShot >= 1/weapons[currentWeaponIndex].attackSpeed)
            {
                animator.SetTrigger("Attack");
                weapons[currentWeaponIndex].Shoot();
                stopwatch.Restart();
            }
            lastShot = stopwatch.ElapsedMilliseconds / 1000f;

        }    
    }
}
