using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_movement : StateMachineBehaviour
{
    boss bossComponent;

    Random random = new Random();
    private float timeLimit;
    private float timePast;
    
    private int attackNumber;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackNumber = Random.Range(2, 4);
        bossComponent = animator.GetComponent<boss>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timePast = Time.deltaTime;

        bossComponent.LookAtPlayer();

        if(timeLimit > timePast)
        {
            animator.SetInteger("AttackType", attackNumber);
        }
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
}
