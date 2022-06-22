using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int health;
    public GameObject deathEffect;
    public GameOverScreen gameOverScreen;
    public GameObject damageEffect;
    public int damageHealth;


    public void TakeDamagePlayer(int damage)
    {
        health -= damage;
        damageHealth = health -1 ;
    }

    void Start()
    {

    }

    void Update()
    {
        if (damageHealth<health)
        {
            Instantiate(damageEffect, transform.position, Quaternion.identity);
            damageHealth = health;
        }

        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);

        } 
    }

    
}
