using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Door : MonoBehaviour
{
    //Start is called before the fist frame update 
    public int redLocks = 1;  //how many keys needed to open this door
   private void OnCollisionEnter(Collision collision)
   {
        //Check if player collided with this door 
        if (collision.gameObject.tag == "Player")
        {
            //stores a refence to the player script 
            Player playerScript = collision.gameObject.GetComponent<Player>();

            //Check if player key is >= this doors number of locks 
            if (playerScript.redKeys >= redLocks)
            {
                print("working door");
                //reduce player key amount and destroy door
                playerScript.redKeys -= redLocks;
                Destroy(gameObject);


            }

          




        }
   }
















}

