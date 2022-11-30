using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDamageable
{

    [SerializeField] [Range(0,100)] int health = 100;
    [SerializeField] Image healthBar;

    private int maxhealth;

    void Start()
    {
        maxhealth = health;
    }

    void Update()
    {
        if (healthBar == null) return;
        healthBar.fillAmount = (float)health / (float)maxhealth;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(health);
        if (health-damage<=0)
        {
            Die();
            return;
        }
        health -= damage;
        Debug.Log(health);
    }
}
