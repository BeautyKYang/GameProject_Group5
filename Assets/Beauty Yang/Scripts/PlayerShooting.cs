using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Beauty Yang
 * 11/20/25
 * Handles the Player shooting out fireballs
 */


public class PlayerShooting : MonoBehaviour
{
    public GameObject Fireball; //Switch this out for the actual fireball prefab
    public GameObject Staff; //Switch this out and put the actual Player prefab

    public Transform aimPoint;

    public float shootingRate = 1f;
    public bool useFireBall = true;

    // Update is called once per frame
    void Update()
    {
        //Fireballs will spawn if space is used
        if (Input.GetKey(KeyCode.Space))
        {
            if (useFireBall)
            {
                //Fireball prefab will spawn
                Instantiate(Fireball, aimPoint.transform.position, aimPoint.transform.rotation);
                useFireBall = false;
                StartCoroutine(DelayFireBall());
            }
        }
    }
    /// <summary>
    /// Delays the execution of fireballs for a second
    /// </summary>
    IEnumerator DelayFireBall()
    {
        //Waits a second before the Player is allowed to shoot out fireballs
        yield return new WaitForSeconds(shootingRate);
        useFireBall = true;
    }
}
