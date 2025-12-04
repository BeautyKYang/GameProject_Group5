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
    public float jumpForce = 0.0f;

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
        Jump();

        float translation = Input.GetAxis("Vertical") * 10 * Time.deltaTime;
        float straffe = Input.GetAxis("Horizontal") * 10 * Time.deltaTime;

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

    private void Jump()
    {
        RaycastHit hit;

        if (Input.GetKey(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
            {
                Debug.Log("Touching the ground");

                //adds force to jump
                body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            else
            {
                Debug.Log("can't jump, not grounded");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "JumpPad")
        {
        }
    }

    IEnumerator JumpPadEffect()
    {
        yield return new WaitForSeconds(5);
        jumpForce = jumpForce * 2;
    }
}
