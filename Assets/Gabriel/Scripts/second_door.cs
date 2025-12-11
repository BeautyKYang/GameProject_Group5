using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class second_door : MonoBehaviour
{
    //Start is called before the fist frame update 
    public int PurpleLocks = 1;
    public int GoldLocks = 1;
    public int CyanLocks = 1;
    public int GreenLocks = 1;

     //how many keys needed to open this door
    private void OnCollisionEnter(Collision other)
    {
        //Check if player collided with this door 
        if (other.gameObject.tag == "Player")
        {
            //stores a refence to the player script 
            Player playerScript = other.gameObject.GetComponent<Player>();

            //Check if player key is >= this doors number of locks 
            if (playerScript.purpleKeys >= PurpleLocks && playerScript.goldKeys >= GoldLocks && playerScript.cyanKeys >= CyanLocks && playerScript.greenKeys >= GreenLocks)
            {
                print("working door");
                //reduce player key amount and destroy door
                playerScript.purpleKeys -= PurpleLocks;
                playerScript.goldKeys -= GoldLocks;
                playerScript.cyanKeys -= CyanLocks;
                playerScript.greenKeys -= GreenLocks;
                Destroy(gameObject);


            }


            


        }

    }
}
