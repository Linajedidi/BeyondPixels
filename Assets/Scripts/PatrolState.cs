using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : StateMachineBehaviour
{
    float timer = 0; 
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;
    Transform player;
    public float chaseRange = 150 ;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        timer = 0;
        GameObject go = GameObject.FindGameObjectWithTag("WayPoints");
        foreach (Transform t in go.transform)
        {
            wayPoints.Add(t);
        }
        if (agent != null)
        {
            agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.speed = 10f; 


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
     
        if (agent != null && wayPoints != null && wayPoints.Count > 0)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
            }

            timer += Time.deltaTime;
            if (timer > 10)
            {
                animator.SetBool("isPatrolling", false);
            }
        }
        else
        {
           
            Debug.LogWarning("Agent or wayPoints is null or empty. Please assign them in the Inspector.");
        }
        float distance = Vector3.Distance(player.position, animator.transform.position);
        //Debug.Log("chaseDistance");
        //Debug.Log(distance);
        if (distance < chaseRange)
        {
            animator.SetBool("isChasing", true);


        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent != null)
        {
            agent.SetDestination(agent.transform.position);
        }

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
