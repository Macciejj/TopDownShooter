using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRange : Weapon
{
    [SerializeField] int ammo = 10;
    [field: SerializeField] public Transform RifflePosition { get; private set; }
    [field: SerializeField] public GameObject Bullet { get; private set; }
    protected GameObject bulletPrefab;
    protected float createTime;


    protected override void Start()
    {
        PerformShooting = CreateBullet;
        base.Start();
    }

    public override void Shoot(Animator animator)
    {       
        base.Shoot(animator);       
    }

    private void CreateBullet()
    {
        Quaternion rotation = transform.rotation;
        createTime = Time.time;
        bulletPrefab = Instantiate(Bullet, RifflePosition.position, rotation);
    }

}
