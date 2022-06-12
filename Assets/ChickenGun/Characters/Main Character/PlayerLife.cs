using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int health;
    public GameObject deathEffect;
    public GameOverScreen gameOverScreen;


    public void TakeDamagePlayer(int damage)
    {
        health -= damage;

    }

    void Start()
    {

    }

    void Update()
    {
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);


        }

    }
}
