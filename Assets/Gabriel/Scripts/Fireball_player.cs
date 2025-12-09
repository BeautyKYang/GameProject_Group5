using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_player : MonoBehaviour
{

   
    public GameObject FireballPrefab;
   
     
   


    public float speed = 20f;

    public void OnTriggerEnter(Collider other)
    {

        //If bullet hits the enemy the enemy dies
        if (other.gameObject.tag == "RegEnemy") 
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        //Bullets will shoot straight ahead
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

}
