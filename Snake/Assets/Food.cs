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

    // Update is called once per frame
    void Update()
    {
        if(transform.position == SnakeBody.snakeBodies[0].position)
        {
            snakeHead.GrowLength();
            foodSpawner.SpawnFood();
            Destroy(gameObject);
        }
    }
}
