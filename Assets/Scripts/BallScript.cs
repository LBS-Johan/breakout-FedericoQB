using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D rb;
    public TextMeshProUGUI pointCounter;
    public GameObject startMessage;
    public string pointsText = "Points: ";
    bool hasStarted = false;
    public bool debugging = false;

    #region NumberVariables
    public static float speed = 5f;
    public float debugSpeed;
    public static int points = 0;
    public static int amountOfBallsTotal = 1;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Starts the game for the first tiem
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed));
        hasStarted = true;

        // Debugging for easy access to features
        if (debugging == true)
        {
            speed = debugSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {

        // Checking if the ball is out of bounds
        if (transform.position.y < -5)
        {
            print("Out Of Bounds");

            if (amountOfBallsTotal > 1)
            {
                amountOfBallsTotal--;
                Destroy(gameObject);
            }
            else
            {
                // Inflicts damage when out of bounds and if it is the last ball
                transform.position = new Vector2(0, -2);
                HealthScript.inflictDamage = true;
                Debug.Log($"Health: {HealthScript.health}");

                // Lets the player choose when to start
                hasStarted = false;
                rb.velocity = new Vector2();
                startMessage.SetActive(true);
            }

            // Resets ball position for the next level
            if (BrickGeneratorScript.totalBricksLeft == 0)
            {
                transform.position = new Vector3(-1.399139f, -1.889436f, 0);
            }
        }

        // Starting or restarting the game
        if (Input.GetKeyDown(KeyCode.F) && hasStarted != true)
        {
            startMessage.SetActive(false);
            hasStarted = true;
            rb.velocity = new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed));
        }
        
        if (hasStarted == true)
        {
            // Keeps the ball at the same speed
            rb.velocity = rb.velocity.normalized * speed;
        }

        if (Input.GetKeyDown(KeyCode.T) && SceneLoaderScript.isPaused == true)
        {
            UnStuckBall();
        }

    }

    // Checks collision and manages point system
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick")
        {
            points = points + collision.gameObject.GetComponent<BrickScript>().amountOfPoints++;
            Debug.Log("Points: " + points);
            pointCounter.text = pointsText + points;
        }
    }

    // Incase ball gets stuck
    void UnStuckBall()
    {
        rb.velocity = new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed));
    }
}
