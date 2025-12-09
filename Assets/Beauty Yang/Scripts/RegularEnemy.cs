using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Beauty Yang
 * 12/2/25
 * Handles Regular Enemy's life and damage it does to the player.
 */

public class RegularEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int lives = 50;

    private void OnTriggerEnter(Collider other)
    {
        //If bullet hits the enemy the enemy dies
        if (other.GetComponent<PlayerFireballTest>()) //Change prefab to actual fireball!
        {
            print("Enemy has been hit");
            DecreaseLife(); //Enemy loses a life
            Destroy(other.gameObject);
        }
    }

    public void DecreaseLife()
    {
        //Subtract one life
        lives -= 15;

        print("Enemy Current Lives: " + lives);

        if (lives <= 0) //Checks life until Regular Enemy is destroyed
        {
            Destroy(gameObject);
            return;
        }
    }
}
