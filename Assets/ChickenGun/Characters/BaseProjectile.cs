using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    [Header ("Movement")]
    public int moveSpeed;
    public Vector2 directionToMove;

    [Header("Life")]

    public float lifetime;
    public float lifetimeSeconds;
    public   Rigidbody2D myRigidBody2D;
    public int damage;
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        lifetimeSeconds = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        lifetimeSeconds -= Time.deltaTime;
        if (lifetimeSeconds <=0)
        {
            Destroy(this.gameObject);
        }

    }

    public void Launch(Vector3 intialVel)
    {

        myRigidBody2D.velocity = intialVel * moveSpeed;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
        this.gameObject.GetComponent<PlayerLife>().TakeDamagePlayer(damage);
    }
}
