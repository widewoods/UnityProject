using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Snake : MonoBehaviour
{
    Vector2 gridUnit = new Vector2(1, 0);

    public static float timer = 0f;
    public static float waitTime = 0.15f;
    public GameObject snakeBodyPrefab;
    public static Vector2 previousPositon;

    public event Action OnGameOver;

    public FoodSpawner foodSpawner;

    KeyCode moveUp = KeyCode.W;
    KeyCode moveDown = KeyCode.S;
    KeyCode moveLeft = KeyCode.A;
    KeyCode moveRight = KeyCode.D;

    // Start is called before the first frame update
    void Start()
    {
        //Reset position to (0, 0) and add the transform to index 0 of snakeBodies
        SnakeBody.snakeBodies.Add(transform);
        transform.position = new Vector3(0, 0, 0);

        //Start with 3 length body
        Instantiate(snakeBodyPrefab, transform.position, Quaternion.identity);
        Instantiate(snakeBodyPrefab, SnakeBody.snakeBodies[SnakeBody.bodyCount].GetComponent<SnakeBody>().previousPosition, Quaternion.identity);
    }

    void Update()
    {
        //Move by one grid unit 
        timer += Time.deltaTime;
        if(timer >= waitTime)
        {
            MoveByOneGrid();
            
            timer = 0f;
        }

        //Check for key presses and change direction
        ChangeDirection();

        //Gameover when snake goes over border
        if (Mathf.Abs(transform.position.x) > FoodSpawner.borderRadius || Mathf.Abs(transform.position.y) > FoodSpawner.borderRadius)
        {
            OnGameOver();
        }


    }

    void MoveByOneGrid()
    {
        //Save previous position and move by one grid unit
        previousPositon = transform.position;
        transform.Translate(gridUnit);

        //Gameover when colliding with own body
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

    //Change direction based on key press
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

    //Instantiate body prefab
    public void GrowLength()
    {
        Instantiate(snakeBodyPrefab, SnakeBody.snakeBodies[SnakeBody.bodyCount].GetComponent<SnakeBody>().previousPosition, Quaternion.identity);
    }
}
