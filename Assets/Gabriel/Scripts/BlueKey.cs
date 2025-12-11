using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Gabriel Delatorre 
 * 12/10/2025
 * Creates pink key to open doors
 */
public class BlueKey : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        //recognize that the player ran into the key 
        if (other.gameObject.tag == "BlueKey")
        {

            //the player collect a key, the key is destroyed 
            GetComponent<Player>().blueKeys++;

            Destroy(other.gameObject);

            print("Working key");
        }
    }
}

