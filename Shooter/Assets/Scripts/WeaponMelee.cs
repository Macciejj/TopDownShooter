using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMelee : Weapon
{
    [SerializeField] int damage;
    [SerializeField] float range;
    [SerializeField] Transform rangeStartPoint;
    [SerializeField] LayerMask targetMask;

    protected override void Start()
    {
        PerformShooting = DealDamageToEnemy;
        base.Start();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(rangeStartPoint.position, range);
    }

    public override void Shoot(Animator animator)
    {
        base.Shoot(animator);
    }

    private void DealDamageToEnemy()
    {
        if (Physics2D.OverlapCircle(rangeStartPoint.position, range, targetMask) == null) return;
        Health enemy = Physics2D.OverlapCircle(rangeStartPoint.position, range, targetMask).GetComponent<Health>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    } 
}
