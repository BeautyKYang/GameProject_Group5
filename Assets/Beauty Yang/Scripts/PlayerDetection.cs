using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

/*
 * Beauty Yang
 * 11/24/25
 * Handles Enemies detecting the Player within range and chasing after them
 */

public class PlayerDetection : MonoBehaviour
{
    public NavMeshAgent enemyAgent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patorling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkingRange;
    public float speed = 5f;

    //Detection
    public float sightRange, attackRange;
    public bool playerInSight, playerInAttackRange;

    private CharacterController enemyController;
    private Rigidbody enemyRb;

    private void Start()
    {
        ActiveEnemy();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSight = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSight && !playerInAttackRange)
        {
            FollowPlayer();
        }
        else
        {
            Patrolling();
        }
    }

    private void ActiveEnemy()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyRb.freezeRotation = true;
    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            Vector3 direction = (walkPoint - transform.position).normalized;
            enemyRb.velocity = direction * speed;
        }
        else
        {
            enemyRb.velocity = Vector3.zero;
        }
    }

    private void SearchWalkPoint()
    {
        //Picks a random point in range
        float randomZ = Random.Range(-walkingRange, walkingRange);
        float randomX = Random.Range(-walkingRange, walkingRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet |= true;
        }
    }

    private void FollowPlayer()
    {
        if (enemyRb == null || player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;

        transform.LookAt(player.position);

        enemyRb.velocity = direction * speed;
    }
}
