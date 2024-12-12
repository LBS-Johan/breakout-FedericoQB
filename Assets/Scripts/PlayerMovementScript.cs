using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    Rigidbody2D rb;

    public static float speed = 2f;
    public float debugSpeed = 2f;
    public bool debugging = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (debugging == true)
        {
            speed = debugSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2();

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x = -1 * speed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction.x = 1 * speed;
        }

        rb.velocity = direction;
    }
}
