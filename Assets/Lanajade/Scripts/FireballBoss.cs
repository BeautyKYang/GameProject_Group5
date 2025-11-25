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
        leftBoundary = maxLeft.transform.position.x;
        rightBoundary = maxRight.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (goingLeft)
        {
            transform.position += speed * Vector3.left * Time.deltaTime;
        }
        else
        {
            transform.position += speed * Vector3.right * Time.deltaTime;
        }

        if (transform.position.x <= leftBoundary || transform.position.x >= rightBoundary)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
