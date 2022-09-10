using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRange : Weapon
{
    [SerializeField] int ammo = 10;
    [field: SerializeField] public Transform RifflePosition { get; private set; }
    [field: SerializeField] public GameObject Bullet { get; private set; }

    public override void Shoot()
    {
        Quaternion rotation = transform.rotation;
        Instantiate(Bullet, RifflePosition.position, rotation);
    }

}
