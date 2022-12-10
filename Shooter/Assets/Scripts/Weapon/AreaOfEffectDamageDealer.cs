using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffectDamageDealer : MonoBehaviour
{
    public static void DealAreaOfEffectDamage(Vector3 centerPosition, float radius, LayerMask targetMask, int damage)
    {
        if (Physics2D.OverlapCircleAll(centerPosition, radius, targetMask) == null) return;
        Collider2D[] enemies = Physics2D.OverlapCircleAll(centerPosition, radius, targetMask);
        foreach (var enemy in enemies)
        {
            if (enemy != null)
            {
                enemy.GetComponent<Health>().TakeDamage(damage);
            }
        }
       
    }
    
}
