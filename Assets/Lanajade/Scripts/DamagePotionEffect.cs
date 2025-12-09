using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Lanajade Dalman
12/8/25
deals with damage potion effect which kills enemies instantly
 */

public class DamagePotionEffect : MonoBehaviour
{
    public bool damageEffectHappening;

    // Start is called before the first frame update
    void Start()
    {
        damageEffectHappening = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RegEnemy" && damageEffectHappening)
        {
            other.gameObject.SetActive(false);
        }
        else
        {
            print("Damage effect not happening right now.");
        }
    }
}
