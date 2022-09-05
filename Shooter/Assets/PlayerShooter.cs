using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] Weapon[] weapons;
    int currentWeaponIndex = 0;
    private float timeBetweenAttacks = 1f;
    float lastShot = 0f;

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
        if(isShooting)
        {
            if (lastShot >= timeBetweenAttacks)
            {
                animator.SetTrigger("Attack");
                weapons[currentWeaponIndex].Shoot();
                lastShot = 0;
            }
        }
        lastShot += Time.deltaTime;

    }

}
