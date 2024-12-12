using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public static int health;
    public static TextMeshProUGUI healthBar;

    static string healthIndicator = "I I I";
    static string secondHealthIndicator = "_ I I";
    static string lastHealthIndicator = "_ _ I";

    // Start is called before the first frame update
    void Start()
    {
        // FIX HEALTH AND HEALTH INDICATORS
        healthBar.text = healthIndicator;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void DamageHealth()
    {
        health--;
        if (health == 2)
        {
            healthBar.text = secondHealthIndicator;
        }else if (health == 1)
        {
            healthBar.text = lastHealthIndicator;
        }
    }
}
