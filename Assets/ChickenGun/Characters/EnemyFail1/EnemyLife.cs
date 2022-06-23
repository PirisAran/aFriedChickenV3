using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int health;
    public GameObject deathEffect;
    public GameObject damageEffect;

    public bool isBoss;

    private bool boolean = false;

    public void TakeDamage(int damage)
    {
        health -= damage;

    }

    void Start()
    {
        
    }

    void Update()
    {
        if (health<=0)
        {
            if (!isBoss)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);


                Destroy(gameObject);
            }
            else
            {
                boolean = true;
            }
        }
        
    }

    public bool IsDead()
    {
        return boolean;
    }
}
