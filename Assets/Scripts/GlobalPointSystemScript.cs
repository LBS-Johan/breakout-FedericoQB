using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlobalPointSystemScript : MonoBehaviour
{
    public TextMeshProUGUI HighscoreText;
    public GameObject ball;
    public string HSText = "HighScore: ";

    int points;

    // Start is called before the first frame update
    void Start()
    {
        if (points < BallScript.points)
        {
            points = BallScript.points;
            BallScript.points = 0;
        }
        

        HighscoreText.text = HSText + points;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
