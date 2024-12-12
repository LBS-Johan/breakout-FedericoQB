using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public static int health = 3;
    public static bool inflictDamage = false;
    public TextMeshProUGUI healthBar;
    public GameObject gameOverCanvas;

    string healthIndicator = "I---I";
    string secondHealthIndicator = "I--I";
    string lastHealthIndicator = "I-I";
    public string deathText;

    // Start is called before the first frame update
    void Start()
    {
        // FIX HEALTH AND HEALTH INDICATORS
        healthBar.text = healthIndicator;
    }

    // Update is called once per frame
    void Update()
    {
        if (inflictDamage == true)
        {
            DamageHealth();
        }
    }

    void DamageHealth()
    {
        health--;
        if (health == 2)
        {
            Debug.Log("2 Lives left");
            healthBar.text = secondHealthIndicator;
        }else if (health == 1)
        {
            Debug.Log ("1 Life Left");
            healthBar.text = lastHealthIndicator;
        }

        if (health <= 0)
        {
            healthBar.text = deathText;
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0;
        }

        inflictDamage = false;
    }
}
