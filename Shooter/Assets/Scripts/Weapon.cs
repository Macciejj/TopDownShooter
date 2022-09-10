using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{    
    public float attackSpeed;
    protected Action PerformShooting;
    private float lastShot = Mathf.Infinity;
    private Stopwatch stopwatch;

    private void Start()
    {
        stopwatch = new Stopwatch();
    }

    public virtual void Shoot(Animator animator)
    {
        if (lastShot >= 1 / attackSpeed)
        {
            animator.SetTrigger("Attack");
            PerformShooting?.Invoke();
            stopwatch.Restart();

        }
        lastShot = stopwatch.ElapsedMilliseconds / 1000f;
    }

}
