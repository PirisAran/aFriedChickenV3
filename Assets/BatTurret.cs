using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTurret : Enemy3AI
{
    public Animator anim;
    public Transform target;
    public float attackRadius;
    public int damage;
    private Rigidbody2D myRigidBody;
    private SpriteRenderer mySpriteRenderer;
    public GameObject projectile;
    public float fireDelay;
    public float fireDelaySeconds;

    private void Update()
    {
        fireDelaySeconds -= Time.deltaTime;
        if (fireDelaySeconds <= 0)
        {
            
        }
    }
    void Start()
    {
        currentState = EnemyState.idle;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;

    }

    void FixedUpdate()
    {
        CheckDistance();
        SetFlipX();

    }

    void CheckDistance()
    {
        Vector2 distance = target.position - transform.position;

        if (Vector3.Distance(target.position, transform.position) <= attackRadius)
        {
       
            AttackCo();
            currentState = EnemyState.walk;
            anim.SetBool("attack", true);


        }
        else
        {
            currentState = EnemyState.idle;
            anim.SetBool("attack", false);


        }

    }

    public void Launcher()
    {
        Vector3 tempVector = target.transform.position - transform.position;
        GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);
        current.GetComponent<BaseProjectile>().Launch(tempVector);
    }


    private void SetFlipX()
    {
        mySpriteRenderer.flipX = target.position.x - transform.position.x < 0;
    }


    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }

    public void AttackCo()
    {
        currentState = EnemyState.attack;
        anim.SetBool("attack", true);
    }

    public void DealDamage()
    {
        target.GetComponent<PlayerLife>().TakeDamagePlayer(damage);

    }
}

