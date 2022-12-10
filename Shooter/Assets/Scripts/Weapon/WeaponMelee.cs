using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMelee : Weapon
{
    [SerializeField] int damage;
    [SerializeField] float range;
    [SerializeField] Transform rangeStartPoint;
    [SerializeField] LayerMask targetMask;

    private void Start()
    {
        PerformAttacking = DealDamageToEnemy;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(rangeStartPoint.position, range);
    }

    public override void Attack(Animator animator)
    {
        base.Attack(animator);
    }

    private void DealDamageToEnemy()
    {
        AreaOfEffectDamageDealer.DealAreaOfEffectDamage(rangeStartPoint.position, range, targetMask, damage);
    }
}
