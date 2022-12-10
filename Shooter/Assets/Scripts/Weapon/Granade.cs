using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Granade : WeaponRange
{
    [SerializeField] float TimeToDetonation = 1f;
    [SerializeField] ParticleSystem ExplosionParticles;
    [SerializeField] float explosionRadius = 1;
    [SerializeField] int damage;
    [SerializeField] LayerMask layerMask;

    private ParticleSystem explosionParticlesPrefab;

    private void Update()
    {
        if (bulletPrefab == null) return;
        if (explosionParticlesPrefab != null) return;

        if ((Time.time - createTime) > TimeToDetonation)
        {
            Explode();
        }
    }

    private void Explode()
    {
        explosionParticlesPrefab = Instantiate(ExplosionParticles, bulletPrefab.transform.position, bulletPrefab.transform.rotation);
        AreaOfEffectDamageDealer.DealAreaOfEffectDamage(bulletPrefab.transform.position, explosionRadius, layerMask, damage);
        Destroy(bulletPrefab);
        Destroy(explosionParticlesPrefab);
    }

    private void OnDrawGizmos()
    {
       if(bulletPrefab!= null) Gizmos.DrawWireSphere(bulletPrefab.transform.position, explosionRadius);
       else Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
