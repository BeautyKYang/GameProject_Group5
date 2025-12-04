using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Dalman, Lanajade
 * 11/24/25
 * Handle health and damage
 */

public class PlayerLives : MonoBehaviour
{
    public int Health;

    // Start is called before the first frame update
    void Start()
    {
        Health = 50;
    }

    private void Update()
    {
        if (Health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RegEnemy")
        {
            Health -= 15;
            print("The enemy hit you! You lost 15 life");
            print("Current Health: " + Health);
        }

        if (other.gameObject.tag == "FireballBoss")
        {
            Health -= 20;
            print("The boss hit you with a fireball! you lose 20 life!");
            print("Current Health: " + Health);
        }

        if(other.gameObject.tag == "DeathFloor")
        {
            Health = 0;
            print("You fell into lava!");
        }
    }
}
