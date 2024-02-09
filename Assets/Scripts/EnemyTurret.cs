using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTurret : MonoBehaviour
{
    public NavMeshAgent turet;
    public Transform player;
    public LayerMask whatIsground, whatIsPlayer;
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public float sightRange, attackRange;
    public bool playerInSightRange;
    public bool playerInAttackRange;
    public GameObject projectile;
    public float health; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        turet = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            AttackPlayer();
        }
    }
    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        if (walkPointSet)
        {
            turet.SetDestination(walkPoint);
        }
        Vector3 distanceTowalkPoint = transform.position - walkPoint;
        //walkpoint reached 
        if (distanceTowalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }
    private void SearchWalkPoint()
    {
        //randomPoint
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x +randomX, transform.position.y,transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, - transform.up, 2f, whatIsground))
        {
            walkPointSet = true;
        }
    }
    private void ChasePlayer()
    {
        turet.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        turet.SetDestination(transform.position);
        transform.LookAt(player);
        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile,transform.position,Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f,ForceMode.Impulse);
            rb.AddForce(transform.up * 8f,ForceMode.Impulse);


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }   

   
}
