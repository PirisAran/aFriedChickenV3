using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log3 : Enemy3AI
{
    private Rigidbody2D myRigidBody;
    private SpriteRenderer mySpriteRenderer;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;

    void Start()
    {
        currentState = EnemyState.idle;
        mySpriteRenderer = GetComponent<SpriteRenderer>();  
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
        //if (currentState == EnemyState.walk)
        //    SetFlipX();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            changeAnim(temp - transform.position);
                myRigidBody.MovePosition(temp);
                ChangeState(EnemyState.walk);
            anim.SetBool("wakeUp", true);
           
           


        }
        if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            ChangeState(EnemyState.idle);
            anim.SetBool("wakeUp", false);
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
            else if(direction.x < 0)
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

    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }

    //private void SetFlipX()
    //{
    //    mySpriteRenderer.flipX = target.position.x - transform.position.x < 0;
    //}
}
