using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [field: SerializeField] public float AttackSpeed { get; protected set; }
    protected Action PerformShooting;
    private RateOfFireLimiter rateOfFireLimiter;

    protected virtual void Start()
    {
        rateOfFireLimiter = new RateOfFireLimiter(AttackSpeed, PerformShooting);
    }

    public virtual void Shoot(Animator animator)
    {
        rateOfFireLimiter.LimitRateOfFire(animator);
    }

}
