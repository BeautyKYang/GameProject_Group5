using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Beauty Yang
 * 11/10/25
 * Handles Player movement
 */
public class PlayerMovement : MonoBehaviour
{


    public float speed = 30f;
    public float jumpForce = 8f;
    public float groundCheckDist = 1.2f;

    public Vector3 direction;
    private Rigidbody rb;

    //camelCasing = Variables
    //PascalCasing = Scripts & Functions

    public int coins = 0;
    public int lives = 99;
    public int gameOver = 0;
    public float deathHeight = -3f;

    private Vector3 respawnPos;

    public float stunTimer = 2f;
    public bool isStunned = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPos = transform.position;
    }

    void Update()
    {
        MovePlayer();
    }
    /// <summary>
    /// Gets user input to move left or right
    /// </summary>
    private void MovePlayer()
    {
        //Get input to move Left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector3.left;
            //transform.position += direction * speed * Time.deltaTime;
            rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
        }

        //Get input to move Right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector3.right;
            //transform.position += direction * speed * Time.deltaTime;
            rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
        }

        //Get input to move forward
        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector3.forward;
            //transform.position += direction * speed * Time.deltaTime;
            rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
        }

        //Get input to move back
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector3.back;
            //transform.position += direction * speed * Time.deltaTime;
            rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
        }
    }
}
