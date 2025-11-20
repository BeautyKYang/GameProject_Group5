using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Beauty Yang
 * 11/20/25
 * Handles the Regular Enemy movement
 */


public class RegularEnemy : MonoBehaviour
{
    public float Speed = 5f;
    public float DetectionDistance = 5f;

    private Vector3 moveDirection;
    private Vector3 startPos;
    private Vector3 targetPos;

    public GameObject enemyPrefab;
    public int lives = 10;

    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDetection();
        MoveToPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerBody")
        {
            print("Player Detected");
        }
    }

    /// <summary>
    /// Perform raycasts downward to detect the player
    /// </summary>
    private void PlayerDetection()
    {
        //Exit this function immediately if moving left or right
        if (isMoving)
            return;

        RaycastHit hit;

        Vector3 rayOrigin = transform.position;

        //Raycast from the right
        if (Physics.Raycast(rayOrigin, Vector3.right, out hit, DetectionDistance))
        {
            //Check if raycast hit the player
            if (hit.transform.GetComponent<PlayerMovement>())
            {
                targetPos = hit.transform.position; //Stores the Player position
                isMoving = true;
            }
        }

        //Raycast from the left
        if (Physics.Raycast(rayOrigin, Vector3.left, out hit, DetectionDistance))
        {
            //Check if raycast hit the player
            if (hit.transform.GetComponent<PlayerMovement>())
            {
                targetPos = hit.transform.position; //Stores the Player position
                isMoving = true;
            }
        }

        //Raycast from the front
        if (Physics.Raycast(rayOrigin, Vector3.left, out hit, DetectionDistance))
        {
            //Check if raycast hit the player
            if (hit.transform.GetComponent<PlayerMovement>())
            {
                targetPos = hit.transform.position; //Stores the Player position
                isMoving = true;
            }
        }

        //Raycast from the back
        if (Physics.Raycast(rayOrigin, Vector3.left, out hit, DetectionDistance))
        {
            //Check if raycast hit the player
            if (hit.transform.GetComponent<PlayerMovement>())
            {
                targetPos = hit.transform.position; //Stores the Player position
                isMoving = true;
            }
        }
    }

    /// <summary>
    /// Hard enemy will move towards the Player
    /// </summary>
    private void MoveToPlayer()
    {
        if (!isMoving)
            return;

        //Calculate the direction towards the Player
        moveDirection = (targetPos - transform.position).normalized;

        //Hard enemy will move
        transform.position += moveDirection * Speed * Time.deltaTime;

        float distanceToTarget = Vector3.Distance(transform.position, targetPos);

        //Stops when the Hard Enemy is close enough
        if (distanceToTarget < 0.05f)
        {
            isMoving = false;
        }
    }
}
