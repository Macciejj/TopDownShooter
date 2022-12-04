using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Granade : WeaponRange
{
    [SerializeField] float TimeToDetonation;
    [SerializeField] float TimeToDestroy = 1f;
    [SerializeField] ParticleSystem ExplosionParticles;
    [SerializeField] Light2D explosionLight;
    private ParticleSystem explosionParticlesPrefab;
    private void Update()
    {
        if (bulletPrefab == null) return;
        if (explosionParticlesPrefab != null) return;

        //explosionLight.intensity

        if ((Time.time - createTime) > TimeToDetonation)
        {
            explosionParticlesPrefab = Instantiate(ExplosionParticles, bulletPrefab.transform.position, bulletPrefab.transform.rotation);
            Destroy(bulletPrefab);
            Destroy(explosionParticlesPrefab);            
        }
    }
}
