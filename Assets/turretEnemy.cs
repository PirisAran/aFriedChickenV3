using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretEnemy : Enemy3AI
{
    public Animator anim;
    public Transform target;
    public float attackRadius;
    public int damage;
    private Rigidbody2D myRigidBody;
    private SpriteRenderer mySpriteRenderer;


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
            changeAnim(distance);


        }
        else
        {
            currentState = EnemyState.idle;
            anim.SetBool("attack", false);


        }

    }

    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("MoveX", setVector.x);
        anim.SetFloat("MoveY", setVector.y);
    }

    private void changeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);

            }

        }
        else if (Mathf.Abs(direction.y) < Mathf.Abs(direction.x))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);

            }
        }
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
