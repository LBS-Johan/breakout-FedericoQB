using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public GameObject player;
    public GameObject brickGenerator;

    #region Colors

    // Colors for the rows depending on which y level
    Color firstRows;
    Color middleRows;
    Color lastRows;

    #endregion

    public int amountOfPoints;
    int totalPoints = 0;
    int maximumBalls = 5;
    int minimumPointsToSpawnBalls = 20;

    // Start is called before the first frame update
    void Start()
    {
        firstRows = BrickGeneratorScript.firstRows;
        middleRows = BrickGeneratorScript.middleRows;
        lastRows = BrickGeneratorScript.lastRows;

        ColorChange();
    }

    // Update is called once per frame
    void Update()
    {
        totalPoints = BallScript.points;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            print("Collided");
            if (totalPoints >= minimumPointsToSpawnBalls && BallScript.amountOfBallsTotal < maximumBalls)
            {
                // Creates a new ball after 20 points
                GameObject newBall = CreateBalls(collision.gameObject);
                newBall.transform.parent = collision.gameObject.transform.parent;
                newBall.GetComponent<Rigidbody2D>().velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;

                // Adds amount of total balls for gameplay
                BallScript.amountOfBallsTotal++;
                BrickGeneratorScript.totalBricksLeft--;

                Destroy(gameObject);
            }
            else if (BallScript.amountOfBallsTotal > maximumBalls)
            {
                BrickGeneratorScript.totalBricksLeft--;
                minimumPointsToSpawnBalls += 30;
                Destroy(gameObject);
            }
            else
            {
                BrickGeneratorScript.totalBricksLeft--;
                Destroy(gameObject);
            }
        }
    }

    // Color for each rows, customizable in brick generator script
    private void ColorChange()
    {
        if (transform.position.y <= 0.5f)
        {
            transform.GetComponent<SpriteRenderer>().color = firstRows;
            amountOfPoints = 2;
        }
        else if (transform.position.y > 0.5f && transform.position.y <= 2)
        {
            transform.GetComponent<SpriteRenderer>().color = middleRows;
            amountOfPoints = 3;
        }
        else if (transform.position.y > 2)
        {
            transform.GetComponent<SpriteRenderer>().color = lastRows;
            amountOfPoints = 5;
        }
    }

    // Creates new ball
    private GameObject CreateBalls(GameObject ball)
    {
        GameObject newBall = Instantiate(ball, transform.position, Quaternion.identity);

        return newBall;
    }
}
