using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
 * Beauty Yang
 * 12/2/25
 * Manages and updates the player's health
 */

public class UIManager : MonoBehaviour
{
    public PlayerLives PlayerLife;
    public TMP_Text healthText;
    public int Health = 0;

    public Inventory DmgPotion;
    public TMP_Text damagePotionText;
    public int Potion = 0;

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + PlayerLife.Health;
        damagePotionText.text = "Damage Potion: " + DmgPotion.DamagePotion;
    }
}
