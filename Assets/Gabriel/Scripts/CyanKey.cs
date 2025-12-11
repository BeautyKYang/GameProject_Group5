using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyanKey : MonoBehaviour
{
    // Start is called before the first frame update
    //after character collides with a key 
    private void OnTriggerEnter(Collider other)
    {

        //recognize that the player ran into the key
        if (other.tag == "Player")
        {
            //the player collects a key, the key is destroyed 
            other.GetComponent<Player>().cyanKeys++;
            Destroy(gameObject);
        }
    }
}
