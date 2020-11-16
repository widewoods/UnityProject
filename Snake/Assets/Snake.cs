using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Snake : MonoBehaviour
{
    Vector2 gridUnit = new Vector2(1, 0);

    public static float timer = 0f;
    public static float waitTime = 0.2f;
    public GameObject snakeBodyPrefab;
    public static Vector2 previousPositon;

    public event Action OnGameOver;

    int count = 0;

    public FoodSpawner foodSpawner;

    KeyCode moveUp = KeyCode.W;
    KeyCode moveDown = KeyCode.S;
    KeyCode moveLeft = KeyCode.A;
    KeyCode moveRight = KeyCode.D;

    // Start is called before the first frame update
    void Start()
    {
        SnakeBody.snakeBodies.Add(transform);
        transform.position = new Vector3(0, 0, 0);
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
        if (Input.GetKeyDown(KeyCode.G))
        {
            if(timer < waitTime)
            {
                Invoke("GrowLength", waitTime - timer);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            foodSpawner.SpawnFood();
        }
        ChangeDirection();

        if (Mathf.Abs(transform.position.x) > FoodSpawner.borderRadius || Mathf.Abs(transform.position.y) > FoodSpawner.borderRadius)
        {
            OnGameOver();
        }


    }

    void MoveByOneGrid()
    {
        previousPositon = transform.position;
        transform.Translate(gridUnit);

        foreach(Transform bodyPositions in SnakeBody.snakeBodies)
        {
            if(SnakeBody.snakeBodies.IndexOf(bodyPositions) != 0)
            {
                if (transform.position == bodyPositions.position)
                {
                    OnGameOver();
                }
            }
        }
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
        if(count == 0)
        {
            Instantiate(snakeBodyPrefab, Snake.previousPositon, Quaternion.identity);
            count++;
        }
        else
        {
            Instantiate(snakeBodyPrefab, SnakeBody.snakeBodies[SnakeBody.bodyCount].GetComponent<SnakeBody>().previousPosition, Quaternion.identity);
            count++;
        }
    }
}
