using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D rb;
    public TextMeshProUGUI pointCounter;
    public GameObject stuckMessage;
    public string pointsText = "Points: ";
    bool hasStarted = false;
    bool isStuck = false;

    #region NumberVariables
    public float speed;
    public static int points = 0;
    public static int amountOfBallsTotal = 1;
    float yValueCoordinate;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed));
        hasStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        yValueCoordinate = transform.position.y;

        if (transform.position.y < -5)
        {
            print("Out Of Bounds");
            if(amountOfBallsTotal > 1)
            {
                amountOfBallsTotal--;
                Destroy(gameObject);
            }
            else
            {
                transform.position = new Vector2(0, -2);
                HealthScript.DamageHealth();

                // Lets the player choose when to start
                hasStarted = false;
                rb.velocity = new Vector2();
            }

            if (transform.position == new Vector3(yValueCoordinate, transform.position.y))
            {
                isStuck = true;
                stuckMessage.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.T) && isStuck == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
                isStuck = false;
                stuckMessage.SetActive(false);
            }

            if (BrickGeneratorScript.totalBricksLeft == 0)
            {
                transform.position = new Vector3(-1.399139f, -1.889436f, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && hasStarted != true)
        {
            hasStarted = true;
            rb.velocity = new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed));
        }
        
        if (hasStarted == true)
        {
            // Keeps the ball at the same speed
            rb.velocity = rb.velocity.normalized * speed;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick")
        {
            points = points + collision.gameObject.GetComponent<BrickScript>().amountOfPoints++;
            Debug.Log("Points: " + points);
            pointCounter.text = pointsText + points;
        }
    }
}
