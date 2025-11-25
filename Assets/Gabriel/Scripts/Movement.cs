using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 10f;

    private Vector3 direction;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        MovePlayer();


    }

    private void MovePlayer()
    {
        //Get input to move left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {

            direction = Vector3.left;

            transform.position += speed * Time.deltaTime * new Vector3(-1, 0, 0);

        }
        //Get input to move right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector3.right;
            //transform.position += direction * speed * time.deltaTime;
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;


        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector3.up;
            //transform.position += direction * speed * time.deltaTime;
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;


        }


        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction = Vector3.down;
            //transform.position += direction * speed * time.deltaTime;
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;


        }
    }






}
