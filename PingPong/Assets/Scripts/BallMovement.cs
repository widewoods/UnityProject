using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Vector2 position;
    Vector2 collisionPoint;
    Vector2 initialPosition = new Vector2(0, 0);

    public float currentSpeed = 8f;
    public float initialSpeed = 8f;

    public Rigidbody2D rb;
    public ScoreCount scoreCount;

    void Start()
    {
        //Initialize
        StartCoroutine(Initialize());
    }

    void Update()
    {
        //Calculate where the ball will collide
        collisionPoint = CheckCollisionPoint();

        //Button for resetting ball
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(Initialize());
        }

        //Always keep the ball at the current speed
        //Can add acceleration by increasing currentSpeed
        rb.velocity = rb.velocity.normalized * currentSpeed;
    }

    //Decided to use trigger instead of collider since I think collider messed with the bounce calculations.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Calculate the vector of the ball to bounce it off
        Vector2 direction;
        direction = collisionPoint - position;

        //Flip vector according to the tag
        //Flip by the X axis if the trigger is vertical
        //Flip by the Y axis if the trigger is horizontal
        if (collision.gameObject.tag == "Vertical")
        {
            direction.Scale(new Vector2(-1, 1));
        }
        else if (collision.gameObject.tag == "Horizontal")
        {
            direction.Scale(new Vector2(1, -1));
        }

        //Normalize direction and set velocity of ball
        direction = direction.normalized;
        rb.velocity = direction * currentSpeed;

        //Check the next collision point and save current position for calculating the next direction
        collisionPoint = CheckCollisionPoint();
        position = transform.position;

        //Score a goal when entering goal trigger
        ScoreGoal(collision);
    }

    Vector2 CheckCollisionPoint()
    {
        //Raycast in the current direction vector of the ball
        RaycastHit2D hit;
        Vector2 currentDirection = rb.velocity.normalized;
        hit = Physics2D.Raycast(transform.position, currentDirection);

        return hit.point;
    }

    //Score goal and reset the ball
    void ScoreGoal(Collider2D collision)
    {
        if(collision.gameObject.name == "Left Goal")
        {
            scoreCount = GameObject.Find("Right Score").GetComponent<ScoreCount>();
            scoreCount.Score();
            StartCoroutine(Initialize());
        }

        else if (collision.gameObject.name == "Right Goal")
        {
            scoreCount = GameObject.Find("Left Score").GetComponent<ScoreCount>();
            scoreCount.Score();
            StartCoroutine(Initialize());
        }
    }

    //Function for resetting ball
    IEnumerator Initialize()
    {
        //Reset and freeze ball
        Vector2 direction = Vector2.zero;
        transform.position = initialPosition;
        rb.velocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        //Wait to give players time
        yield return new WaitForSeconds(1.2f);

        //Send the ball in a random direction
        direction = new Vector2(Random.Range(-4f, 4f), Random.Range(-4f, 4f));
        rb.constraints = RigidbodyConstraints2D.None;
        rb.velocity = direction * initialSpeed;

        //Check the next collision point and save current position for calculating the next direction
        collisionPoint = CheckCollisionPoint();
        position = transform.position;

        //Reset speed(if acceleration is added)
        currentSpeed = initialSpeed;
    }
}
