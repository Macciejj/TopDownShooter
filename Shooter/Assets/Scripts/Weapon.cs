using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [field: SerializeField] public float AttackSpeed { get; protected set; }
    protected Action PerformShooting;
    private float lastShot = Mathf.Infinity;
    private Stopwatch stopwatch;

    private void Start()
    {
        stopwatch = new Stopwatch();
    }

    public virtual void Shoot(Animator animator)
    {
        if (lastShot >= 1 / AttackSpeed)
        {
            AudioManager.instance.Play("RiffleShot");
            animator.SetTrigger("Attack");
            PerformShooting?.Invoke();
            stopwatch.Restart();

        }
        lastShot = stopwatch.ElapsedMilliseconds / 1000f;
    }

}
