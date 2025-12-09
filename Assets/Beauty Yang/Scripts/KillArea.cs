using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Beauty Yang
 * 12/08/25
 * Handles the Kill Area of the spiked obstacle. If the player collides with the area, the player dies and respawns.
 */

public class KillArea : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Check if Player collided with this object
        if (collision.gameObject.GetComponent<RespawnPoint>())
        {
            //Respawn the player
            collision.gameObject.GetComponent<RespawnPoint>().Respawn();
        }
    }
}
