using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBoss : MonoBehaviour
{
    [Header("Projectile Variables")]
    public float speed;
    public bool goingLeft;
    public GameObject maxLeft;
    public GameObject maxRight;
    public float leftBoundary;
    public float rightBoundary;

    /*
 * Dalman, Lanajade
 * 11/24/25
 * Handle the fireball the boss shoots
 */

    void Start()
    {
        leftBoundary = maxLeft.transform.position.z;
        rightBoundary = maxRight.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (goingLeft)
        {
            transform.position += speed * Vector3.back * Time.deltaTime;
        }
        else
        {
            transform.position += speed * Vector3.forward * Time.deltaTime;
        }

        if (transform.position.z <= leftBoundary || transform.position.z >= rightBoundary)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cover")
        {
            Destroy(gameObject);
        }
    }
}
