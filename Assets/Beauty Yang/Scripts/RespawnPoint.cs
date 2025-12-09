using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Beauty Yang
 * 12/8/25
 * Handles spawn point. If the player dies they'll respawn back to their previous point
 */

public class RespawnPoint : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 respawnPos;
    public int Health = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPos = transform.position;
    }

    /// <summary>
    /// Teleport player back to starting position, and decrease lives
    /// </summary>
    public void Respawn()
    {
        transform.position = respawnPos;

        //Check if no lives left. Player will respawn back to their respective level
        if (Health <= 0)
        {
            //Recieves the current index that the player is in
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            //Player will respawn to the beginning of the spawn point of the level they're in
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
