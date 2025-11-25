using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Dalman, Lanajade
 * 11/24/25
 * Handles player movement
 */

public class PlayerMove : MonoBehaviour
{
    private bool is_grounded;

    //The rigid body attached to the player
    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * 10 * Time.deltaTime;
        float straffe = Input.GetAxis("Horizontal") * 10 * Time.deltaTime;

        if (!is_grounded)
            straffe /= 2;

        if (!is_grounded)
            translation /= 2;

        //Translate to move.
        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
