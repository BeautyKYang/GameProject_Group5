using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_fireball : MonoBehaviour
{


    public GameObject Fireball;

    public int FireBall = 1;

        public float speed = 20f;

        private void Update()
        {
            //Fireball will shoot straight ahead
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
 

}
