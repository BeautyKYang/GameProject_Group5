using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
/*
 * Gabriel Delatorre 
 * 12/10/2025
 * Creates redkey to open doors
 */
public class Redkey : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        //recognize that the player ran into the key 
        if (other.gameObject.tag == "RedKey")
        {

          //the player collect a key, the key is destroyed 
            GetComponent<Player>().redKeys++;

            Destroy(other.gameObject);

            print("Working key");
        }
    }


    







}