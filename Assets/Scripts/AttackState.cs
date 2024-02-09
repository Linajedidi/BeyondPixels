using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    float timer = 0;
    int damage = 10;
    public float toStopAttack = 20f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.speed = 120f;
        timer = Time.time;

    }


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);
        PlayerDamage pdamage = player.GetComponent<PlayerDamage>();
        if (pdamage.GetHp() <= 0)
        {
            animator.SetBool("IsAttacking", false);
            return;
        }
        if (Time.time - timer > 1)
        {
            pdamage.TakeDamage(damage);
            timer = Time.time;
        }
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > toStopAttack)
        {
            animator.SetBool("IsAttacking", false);
        }
    }




    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
