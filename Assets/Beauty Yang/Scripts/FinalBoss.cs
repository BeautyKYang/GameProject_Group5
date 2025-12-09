using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * Beauty Yang
 * 12/4/25
 * Handles the Final Boss's movements
 */

public class FinalBoss : MonoBehaviour
{
    public GameObject FinalBossprefab;
    public int lives = 100;

    public float leftBounds = 0f;
    public float rightBounds = 0f;
    public Vector3 moveDirection;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection = Vector3.left;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;

        //Check if enemy reaches the left side bounds or is less than it
        if (moveDirection == Vector3.left && transform.position.x <= leftBounds)
        {
            //Enemy goes back to the right
            moveDirection *= -1;
        }

        //Check if enemy reaches the right side bounds or is greater than it
        if (moveDirection == Vector3.right && transform.position.x >= rightBounds)
        {
            //Enemy goes back to the left
            moveDirection *= -1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If bullet hits the boss the enemy dies
        if (other.GetComponent<PlayerFireballTest>()) //Change prefab to actual fireball!
        {
            print("Final Boss has been hit");
            DecreaseLife(); //Boss loses a life
            Destroy(other.gameObject);
        }
    }

    public void DecreaseLife()
    {
        //Subtract one life
        lives -= 15;

        if (lives <= 0) //Checks lives until Final Boss is destroyed
        {
            Destroy(gameObject);
            return;
        }
    }
}
