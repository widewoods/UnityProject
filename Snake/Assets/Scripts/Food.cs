using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    Snake snakeHead;
    FoodSpawner foodSpawner;

    private void Start()
    {
        snakeHead = FindObjectOfType<Snake>();
        foodSpawner = FindObjectOfType<FoodSpawner>();
    }

    void Update()
    {
        //Spawn another food and grow length of snake
        if(transform.position == SnakeBody.snakeBodies[0].position)
        {
            snakeHead.GrowLength();
            foodSpawner.SpawnFood();
            Destroy(gameObject);
        }
    }
}
