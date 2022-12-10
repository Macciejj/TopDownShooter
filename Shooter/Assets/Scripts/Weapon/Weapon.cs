using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    [field: SerializeField] public float AttackSpeed { get; protected set; }
    [field: SerializeField] public string SoundName { get; protected set; }
    protected float lastAttack = Mathf.Infinity;
    private bool canAttack = true;
    protected Action PerformAttacking;

    private void Update()
    {
        CheckRateOfFire();
    }

    private void CheckRateOfFire()
    {
        if (lastAttack >= 1 / AttackSpeed)
        {
            canAttack = true;
            lastAttack = 0;
        }
        lastAttack += Time.deltaTime;
    }

    public virtual void Attack(Animator animator)
    {
        if (canAttack)
        {
            canAttack = false;
            animator.SetBool("Attack", true);
            AudioManager.instance.Play(SoundName);
            this.PerformAttacking?.Invoke();
        }
    }

}
