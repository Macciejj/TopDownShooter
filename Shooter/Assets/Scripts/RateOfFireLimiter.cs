using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RateOfFireLimiter
{
    private float lastShot = Mathf.Infinity;
    private Stopwatch stopwatch;
    private Action PerformShooting;
    private float attackSpeed;

    public RateOfFireLimiter(float attackSpeed, Action performShooting)
    {
        stopwatch = new Stopwatch();
        this.attackSpeed = attackSpeed;
        PerformShooting = performShooting;
    }

    public void LimitRateOfFire(Animator animator)
    {
        if (lastShot >= 1 / attackSpeed)
        {
            AudioManager.instance.Play("RiffleShot");
            animator.SetTrigger("Attack");
            PerformShooting?.Invoke();
            stopwatch.Restart();

        }
        lastShot = stopwatch.ElapsedMilliseconds / 1000f;
    }
    
}
