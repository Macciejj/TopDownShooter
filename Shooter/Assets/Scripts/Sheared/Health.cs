using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDamageable
{

    [SerializeField] [Range(0,100)] int health = 100;

    [SerializeField] Image healthBar;

    [SerializeField] ParticleSystem explosionParticleSystem;

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
        if(explosionParticleSystem!=null) Instantiate(explosionParticleSystem, transform.position, transform.rotation);
        Behaviour[] behaviours = gameObject.GetComponentsInChildren<Behaviour>();
        gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        foreach (var item in behaviours)
        {
            if(item!=this) item.enabled = false;
        }
        Destroy(gameObject, 2);
    }

    public void TakeDamage(int damage)
    {
        if (health-damage<=0)
        {
            Die();
            return;
        }
        health -= damage;
    }
}
