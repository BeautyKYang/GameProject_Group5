using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


/*
 * Beauty Yang
 * 12/4/25
 * Manages the Final Boss's health
 */

public class UIManagerFinalBoss : MonoBehaviour
{
    public FinalBoss Life;
    public TMP_Text FinalBossHealthText;
    public int lives = 0;

    // Update is called once per frame
    void Update()
    {
        FinalBossHealthText.text = "Final Boss: " + Life.lives;
    }
}
