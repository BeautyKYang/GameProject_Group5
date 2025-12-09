using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Beauty Yang
 * 12/08/25
 * Handles the timing of regular enemies spawning
 */

public class EnemySpawning : MonoBehaviour
{
    public GameObject RegularEnemyPrefab;

    private float EnemySwarm = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(EnemySwarm, RegularEnemyPrefab));
    }

    private IEnumerator spawnEnemy(float EnemySwarm, GameObject RegularEnemyPrefab)
    {
        yield return new WaitForSeconds(EnemySwarm); //Wait for the swarm to take place

        //Random range where the enemies will spawn in
        GameObject newEnemy = Instantiate(RegularEnemyPrefab, new Vector3(Random.Range(-5, 5), Random.Range(-6, 6), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(EnemySwarm, RegularEnemyPrefab));
    }
}
