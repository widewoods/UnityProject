using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 position;
    Vector2 collisionPoint;
    Vector2 initialPosition = new Vector2(0, 0);
    public float currentSpeed = 8f;
    public float initialSpeed = 8f;

    public ScoreCount scoreCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Initialize());
    }

    // Update is called once per frame
    void Update()
    {
        collisionPoint = CheckCollisionPoint();
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(Initialize());
        }
        rb.velocity = rb.velocity.normalized * currentSpeed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 direction;
        direction = collisionPoint - position;
        
        if (collision.gameObject.tag == "Vertical")
        {
            direction.Scale(new Vector2(-1, 1));
        }
        else if (collision.gameObject.tag == "Horizontal")
        {
            direction.Scale(new Vector2(1, -1));
        }
        direction = direction.normalized;

        rb.velocity = direction * currentSpeed;

        collisionPoint = CheckCollisionPoint();
        position = transform.position;

        ScoreGoal(collision);
    }

    Vector2 CheckCollisionPoint()
    {
        RaycastHit2D hit;
        Vector2 currentDirection = rb.velocity.normalized;
        hit = Physics2D.Raycast(transform.position, currentDirection);

        return hit.point;

    }

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

    IEnumerator Initialize()
    {
        Vector2 direction = Vector2.zero;
        transform.position = initialPosition;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(1.2f);
        direction = new Vector2(Random.Range(-4f, 4f), Random.Range(-4f, 4f));

        rb.velocity = direction * initialSpeed;
        collisionPoint = CheckCollisionPoint();
        position = transform.position;
        currentSpeed = initialSpeed;
    }
}
