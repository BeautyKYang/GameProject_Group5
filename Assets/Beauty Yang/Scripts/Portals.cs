using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Beauty Yang
 * 12/4/25
 * Handles the transportation of portals and the player spawning to other areas
 */

public class Portals : MonoBehaviour
{
    public Transform teleportPoint;
    private void OnTriggerEnter(Collider other)
    {
        //Sets the touched object's position to the teleport point's position
        other.transform.position = teleportPoint.position;
    }
}
