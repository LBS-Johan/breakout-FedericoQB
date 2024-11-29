using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed));
    }

    // Update is called once per frame
    void Update()
    {
        // Keeps the ball at the same speed
        rb.velocity = rb.velocity.normalized * speed;

        if (transform.position.y < -5)
        {
            print("Out Of Bounds");
            transform.position = new Vector2();
        }
    }
}
