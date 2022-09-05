using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] [Range(0,100)] int health = 10;
    private void Die()
    {
        print("boom");
    }

    public void TakeDamage(int damage)
    {
        if(health-damage<=0)
        {
            Die();
            return;
        }
        health -= damage;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
