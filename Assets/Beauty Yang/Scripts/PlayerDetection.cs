using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
 * Beauty Yang
 * 11/24/25
 * Handles Enemies detecting the Player within range and chasing after them
 */

public class PlayerDetection : MonoBehaviour
{
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

        //Player is detected
        if (playerInSight && playerInAttackRange)
        {
            FollowPlayer();
        }
        else //Player is not detected
        {
            Patrolling();
        }
    }

    private void ActiveEnemy()
    {
        //Gets the enemy rigibody component
        enemyRb = GetComponent<Rigidbody>();

        //Find the player's transform by the tag
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (enemyRb != null)
        {
            enemyRb.freezeRotation = true;
        }
    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            //Calculates the direction
            Vector3 direction = (walkPoint - transform.position).normalized;

            //Sets the rigidbody's velocity
            enemyRb.velocity = direction * speed;
        }
        else
        {
            //Stop movement when patrolling is complete
            enemyRb.velocity = Vector3.zero;
        }
    }

    private void SearchWalkPoint()
    {
        //Picks a random point in range
        float randomZ = Random.Range(-walkingRange, walkingRange);
        float randomX = Random.Range(-walkingRange, walkingRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        RaycastHit hit;

        if (Physics.Raycast(walkPoint, Vector3.down, out hit, 5f, whatIsGround))
        {
            walkPoint.y = hit.point.y + 0.1f;
            walkPointSet = true;
        }
        else
        {
            walkPointSet = false;
        }
    }

    private void FollowPlayer()
    {
        if (enemyRb == null || player == null) return;

        //Calculate the direction vector from enemy to player
        Vector3 direction = (player.position - transform.position).normalized;

        //Rotate the enemy to face the player
        transform.LookAt(player.position);

        //CharacterController will move the enemy
        enemyRb.velocity = direction * speed;
    }
}
