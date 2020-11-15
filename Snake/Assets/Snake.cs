using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2 gridUnit = new Vector2(1, 0);

    public static float timer = 0f;
    public static float waitTime = 0.2f;
    public GameObject snakeBodyPrefab;
    public static Vector2 previousPositon;

    KeyCode moveUp = KeyCode.W;
    KeyCode moveDown = KeyCode.S;
    KeyCode moveLeft = KeyCode.A;
    KeyCode moveRight = KeyCode.D;

    // Start is called before the first frame update
    void Start()
    {
        SnakeBody.snakeBodies.Add(transform);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= waitTime)
        {
            MoveByOneGrid();
            
            timer = 0f;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(timer < waitTime)
            {
                Invoke("GrowLength", waitTime - timer);
            }
        }
        ChangeDirection();
    }

    void MoveByOneGrid()
    {
        previousPositon = transform.position;
        transform.Translate(gridUnit);
    }

    void ChangeDirection()
    {
        if (Input.GetKeyDown(moveUp))
        {
            gridUnit = Vector2.up;
        }
        else if (Input.GetKeyDown(moveDown))
        {
            gridUnit = Vector2.down;
        }
        else if (Input.GetKeyDown(moveLeft))
        {
            gridUnit = Vector2.left;
        }
        else if (Input.GetKeyDown(moveRight))
        {
            gridUnit = Vector2.right;
        }
    }

    public void GrowLength()
    {
        Instantiate(snakeBodyPrefab, SnakeBody.snakeBodies[SnakeBody.bodyCount].transform.position, Quaternion.identity);
        //Instantiate(snakeBodyPrefab, transform.position, Quaternion.identity);
    }
}
