using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float attackSpeed;
    public abstract void Shoot();
    private bool canShoot = true;
}
