using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMelee : Weapon
{
    [SerializeField] int damage;
    [SerializeField] float range;
    [SerializeField] Transform rangeStartPoint;
    [SerializeField] LayerMask enemyMask;
    public override void Shoot()
    {
        if (Physics2D.OverlapCircle(rangeStartPoint.position, range, enemyMask) == null) return;
        Health enemy = Physics2D.OverlapCircle(rangeStartPoint.position, range, enemyMask).GetComponent<Health>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(rangeStartPoint.position, range);
    }
}
