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
        
    }

    void Move(string player)
    {
        if(player == "left")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(transform.up * speed * Time.deltaTime);
                //transform.Translate(transform.up * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(-transform.up * speed * Time.deltaTime);
                //transform.Translate(-transform.up * speed * Time.deltaTime);
            }
        }

        if(player == "right")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.AddForce(transform.up * speed * Time.deltaTime);
                //transform.Translate(transform.up * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.AddForce(-transform.up * speed * Time.deltaTime);
                //transform.Translate(-transform.up * speed * Time.deltaTime);
            }
        }

        if(player == "AI")
        {
            //if(transform.position.y < ballRb.gameObject.transform.position.y)
            //{
            //    rb.AddForce(transform.up * speed * Time.deltaTime);
            //}
            //else if (transform.position.y > ballRb.gameObject.transform.position.y)
            //{
            //    rb.AddForce(-transform.up * speed * Time.deltaTime);
            //}
            //else
            //{
            //    rb.velocity = Vector2.zero;
            //}

            transform.position = new Vector2(transform.position.x, ballRb.gameObject.transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            ballRb.AddForce(rb.velocity * 4);
        }

        if(collision.gameObject.tag == "Horizontal")
        {
            rb.velocity = Vector2.zero;
        }
    }
}
