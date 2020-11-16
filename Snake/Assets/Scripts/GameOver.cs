using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Transform snakeHead;
    Vector2 headPosition;

    public Snake snake;

    void Start()
    {
        snake = FindObjectOfType<Snake>().GetComponent<Snake>();

        //Subscribe GameOverMethod to OnGameOver
        snake.OnGameOver += GameOverMethod;
    }

    void GameOverMethod()
    {
        //Disable corresponding body's script to stop snake
        foreach (Transform bodyPosition in SnakeBody.snakeBodies)
        {
            
            if (SnakeBody.snakeBodies.IndexOf(bodyPosition) == 0)
            {
                bodyPosition.position = Snake.previousPositon;
                bodyPosition.gameObject.GetComponent<Snake>().enabled = false;
            }

            else
            {
                bodyPosition.gameObject.GetComponent<SnakeBody>().enabled = false;
            }
        }

        StartCoroutine(ChangeDeathColor());
    }

    //Change color to grey from head to tail
    IEnumerator ChangeDeathColor()
    {
        foreach(Transform elem in SnakeBody.snakeBodies)
        {
            elem.gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
            yield return new WaitForSeconds(0.024f);
        }
    }
}
