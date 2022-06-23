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
    public GameObject[] hearts;


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
        //if (damageHealth<health)
        //{
        //    Instantiate(damageEffect, transform.position, Quaternion.identity);
        //    HeartSystem();

        //    damageHealth = health;
        //}

        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            if (health < 1)
            {
                Destroy(hearts[0].gameObject);
            }
            Destroy(gameObject);

        }
        else
        {
            HeartSystem();
        }

    }

    public void HeartSystem()
    {
        if (health < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if (health < 3)
        {
            Destroy(hearts[2].gameObject);
        }
        else if (health < 4)
        {
            Destroy(hearts[3].gameObject);
        }
        else if (health < 5)
        {
            Destroy(hearts[4].gameObject);
        }
        else if (health < 6)
        {
            Destroy(hearts[5].gameObject);
        }
    }

    
}
