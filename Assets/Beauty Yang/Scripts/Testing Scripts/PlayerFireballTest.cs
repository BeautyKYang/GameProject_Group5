using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Beauty Yang
 * 11/20/25
 * Testing script to see if the fireball will move forward
 */

public class PlayerFireballTest : MonoBehaviour
{
    public GameObject FireBall_Test;

    public int FireBall = 1;

    public float speed = 20f;

    private void Update()
    {
        //Fireball will shoot straight ahead
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
