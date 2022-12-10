using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRange : Weapon
{
    [field: SerializeField] public int MaxBullets { get; private set; } = 10; 
    public int CurrentBullets { get; private set; }
    [field: SerializeField] public int MaxAmmo { get; private set; } = 2;
    public int CurrentMagazines { get; private set; }
    [field: SerializeField] public Transform RifflePosition { get; private set; }
    [field: SerializeField] public GameObject Bullet { get; private set; }
    [field: SerializeField] public float ReloadTime { get; private set; } = 1f;


    protected GameObject bulletPrefab;
    protected float createTime;

    private bool isReloading = false;

    protected void Start()
    {
        CurrentBullets = MaxBullets;
        CurrentMagazines = MaxAmmo;
        PerformAttacking = CreateBullet;
    }

    public override void Attack(Animator animator)
    {       
        if (CurrentBullets > 0 && !isReloading)
        {           
            base.Attack(animator);
        }
        if(CurrentBullets <= 0 && MaxAmmo > 0 && !isReloading)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(ReloadTime);
        CurrentMagazines--;
        CurrentBullets = MaxBullets;
        isReloading = false;
    }

    private void CreateBullet()
    {
        Quaternion rotation = transform.rotation;
        createTime = Time.time;
        bulletPrefab = Instantiate(Bullet, RifflePosition.position, rotation);
        CurrentBullets--;
    }

}
