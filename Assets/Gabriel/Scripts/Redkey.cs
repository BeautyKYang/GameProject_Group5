using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redkey : MonoBehaviour
{
    //after character collides with a key 
    public void OnTriggerEnter(Collider other)
    {

        //recognize that the player ran into the key
        if (other.tag == "Player")
        {
            //the player collects a key, the key is destroyed 
            other.GetComponent<Player>().redKeys++;
            
            Destroy(gameObject);
        }

    }
}