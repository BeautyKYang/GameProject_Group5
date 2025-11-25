using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Projectile Variables")]
    public bool goingLeft;

    [Header("Spawner Variables")]
    public GameObject projectilePrefab;
    public float timeBetweenShots;
    public float startDelay;

    private void Start()
    {
        InvokeRepeating("SpawnProjectile", startDelay, timeBetweenShots);
    }

    // Update is called once per frame
    public void SpawnProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

        if (projectile.GetComponent<FireballBoss>())
        {
            projectile.GetComponent<FireballBoss>().goingLeft = goingLeft;
        }
    }
}
