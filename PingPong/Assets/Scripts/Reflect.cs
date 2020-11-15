using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------------------------------------------------
//First try at making ball reflect off colliders. Bouncing is now moved to BallMovement.cs
//----------------------------------------------------------------------------------------

public class Reflect : MonoBehaviour
{

    GameObject ball;
    Rigidbody2D ballRb;
    CircleCollider2D ballCollider;

    Vector2 collisionPoint;
    Vector2 ballPos;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
        ballCollider = ball.GetComponent<CircleCollider2D>();
        ballRb = ball.GetComponent<Rigidbody2D>();

        collisionPoint = CheckCollisionPoint();
        ballPos = new Vector2(ball.transform.position.x, ball.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 direction;
        if (collision.gameObject.name == "Ball")
        {
            Debug.Log("Collided");
            direction = ballPos - collisionPoint;
            //FlipVector(direction);
            direction = direction.normalized;
            Vector2.Reflect(direction, collision.contacts[0].normal);
            //ballRb.velocity = direction * BallMovement.speed;

            ballPos = new Vector2(ball.transform.position.x, ball.transform.position.y);
            collisionPoint = CheckCollisionPoint();
        }
    }

    void FlipVector(Vector2 direction)
    {
        if(gameObject.tag == "Vertical")
        {
            direction.Scale(new Vector2(-1, 1));
            
        }
        else if (gameObject.tag == "Horizontal")
        {
            direction.Scale(new Vector2(1, -1));
        }
    }

    Vector2 CheckCollisionPoint()
    {
        RaycastHit2D hit;
        Vector2 currentDirection = ballRb.velocity.normalized;
        hit = Physics2D.Raycast(ball.transform.position, currentDirection, 10);

        Debug.Log(hit.point);
        Debug.DrawRay(ball.transform.position, currentDirection, Color.yellow);
        
        return hit.point;
        
    }
}
