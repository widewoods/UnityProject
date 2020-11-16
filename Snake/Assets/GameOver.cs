using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Transform snakeHead;
    Vector2 headPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        headPosition.x = snakeHead.position.x;
        headPosition.y = snakeHead.position.y;

        if (Mathf.Abs(headPosition.x) > FoodSpawner.borderRadius || Mathf.Abs(headPosition.y) > FoodSpawner.borderRadius)
        {
            GameOverMethod();
        }
    }

    public void GameOverMethod()
    {
        Debug.Log("GameOver");
    }
}
