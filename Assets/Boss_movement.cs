using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_movement : StateMachineBehaviour
{
    boss bossComponent;
    EnemyLife bossLiveComponent;

    [SerializeField] GameObject player;
    public Vector3 playerPosition;
    public Vector3 bossPosition;
    Vector3 vectorBossPlayer;
    public float distanceToBoss;

    private Rigidbody2D myRigidBody;

    Random random = new Random();
    public float timeLimit;
    public float timePast;
    
    private int attackNumber;

    // vida boss ----------
    //public int health = 10;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Dies", false);

        timePast = 0;
        timeLimit = 0;
        //health = 10;

        attackNumber = Random.Range(2, 4);
        bossComponent = animator.GetComponent<boss>();
        bossLiveComponent = animator.GetComponent<EnemyLife>();
        timeLimit = Random.Range(3f, 6f);

        player = GameObject.FindGameObjectWithTag("Player");

        bossPosition = bossComponent.GetComponent<Transform>().position;

        myRigidBody = bossComponent.GetComponent<Rigidbody2D>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timePast += Time.deltaTime;
        bossComponent.LookAtPlayer();

        if (bossLiveComponent.IsDead())
        {
            animator.SetBool("Dies", true);
        }

        //playerPosition = player.GetComponent<Transform>().position;

        //vectorBossPlayer = (playerPosition - bossPosition).normalized;

        //vectorPosition = bossPosition + vectorBossPlayer * Time.deltaTime;

        //myRigidBody.MovePosition(vectorPosition);
        playerPosition = player.transform.position;

        vectorBossPlayer = playerPosition - bossPosition;
        distanceToBoss = vectorBossPlayer.magnitude;
        
        if(distanceToBoss < 10)
        {
            if (timePast > timeLimit)
            {
                animator.SetInteger("AttackType", attackNumber);
            }
        }

        //if (health <= 0)
        //{
        //    animator.SetBool("Dies", true);
            
        //    //Instantiate(deathEffect, transform.position, Quaternion.identity);


        //    //Destroy(gameObject);
        //}
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("AttackType", 0);
    }

    private void CanMeleeAttack(Animator animator)
    {
        //if (animator.GetComponentInParent<BoxCollider2D>().IsTouching(player.GetComponent<BoxCollider2D>()))
        //{
        //    animator.SetInteger("AttackType", 1);
        //}
    }

    //public void TakeDamage(int damage)
    //{
    //    health -= damage;
    //}
}
