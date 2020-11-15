using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarControl : MonoBehaviour
{
    public float speed;
    public string player;

    public Rigidbody2D rb;
    Rigidbody2D ballRb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballRb = FindObjectOfType<BallMovement>().gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(player);

        //Bounds the paddles inside the game scene
        if(transform.position.y > 4.28f)
        {
            transform.position = new Vector2(transform.position.x, 4.28f);
        }
        if (transform.position.y < -4.28f)
        {
            transform.position = new Vector2(transform.position.x, -4.28f);
        }
    }

    void Move(string player)
    {
        //Code for left player
        if(player == "left")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(transform.up * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(-transform.up * speed * Time.deltaTime);
            }
        }

        //Code for right player
        if(player == "right")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.AddForce(transform.up * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.AddForce(-transform.up * speed * Time.deltaTime);
            }
        }

        //Code for AI
        if(player == "AI")
        {
            //Follows the ball's y position for now
            //Todo: Calculate the ball's trajectory and move the paddle
            transform.position = new Vector2(transform.position.x, ballRb.gameObject.transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When colliding with ball, add the current paddle velocity to the ball
        if(collision.gameObject.tag == "Ball")
        {
            ballRb.AddForce(rb.velocity * 4);
        }
    }
}
