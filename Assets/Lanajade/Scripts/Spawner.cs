using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Dalman, Lanajade
* 12/2/25
* Handle the spawning of fireballs the boss shoots
*/

public class Spawner : MonoBehaviour
{
    [Header("Projectile Variables")]
    public bool goingLeft;

    [Header("Spawner Variables")]
    public GameObject projectilePrefab;
    public float timeBetweenShots;
    public float startDelay;

    //coroutine variables
    public float shootingRate = 1f;
    public bool useFireBall = true;

    private void Start()
    {
        InvokeRepeating("SpawnProjectile", startDelay, timeBetweenShots);
    }


    // Update is called once per frame
    public void SpawnProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

        if (projectile.GetComponent<FireballBoss>())
        {
            projectile.GetComponent<FireballBoss>().goingLeft = goingLeft;
        }
    }
}
