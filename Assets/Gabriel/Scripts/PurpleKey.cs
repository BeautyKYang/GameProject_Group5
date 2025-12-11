using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Gabriel Delatorre 
 * 12/10/2025
 * Creates Purplekey to open doors
 */
public class PurpleKey : MonoBehaviour
{
    // Start is called before the first frame update
    //after character collides with a key 
    private void OnTriggerEnter(Collider other)
    {

        //recognize that the player ran into the key
        if (other.gameObject.tag == "PurpleKey")
        {
            //the player collects a key, the key is destroyed 
            other.GetComponent<Player>().purpleKeys++;
            Destroy(gameObject);
        }
    }
}