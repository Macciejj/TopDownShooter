using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamager : MonoBehaviour
{
    [SerializeField] int damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("elo");
        IDamageable target = collision.gameObject.GetComponent<IDamageable>();
        if (target != null)
        {
            target.TakeDamage(damage);
        }
    }
}
