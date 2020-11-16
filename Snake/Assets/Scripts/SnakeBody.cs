using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    //Make a list of all the bodies
    public static List<Transform> snakeBodies = new List<Transform>();

    public GameObject bodyParent;
    public static int bodyCount;
    float timer;

    public Vector2 previousPosition = Vector2.zero;

    [SerializeField]
    int bodyIndex;

    private void Awake()
    {
        //Set timer to match the timer of Snake.cs
        timer = Snake.timer;

        //Set body index and increase bodyCount
        bodyIndex = bodyCount + 1;
        bodyCount = bodyIndex;

        //Add instance of transform to list
        snakeBodies.Add(transform);

        //Code for changing color
        //if(bodyIndex % 2 == 1)
        //{
        //    GetComponent<SpriteRenderer>().color = new Color(0.094f, 0.4f, 0.1f, 1);
        //}
    }

    //Parent bodies to stay organized
    private void Start()
    {
        bodyParent = GameObject.Find("SnakeBody");
        transform.parent = bodyParent.transform;
    }

    //Move based on timer
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= Snake.waitTime)
        {
            FollowBody();
            timer = 0f;
        }
    }

    void FollowBody()
    {
        //Save current position
        previousPosition = transform.position;

        //Index 1 follows head
        if(bodyIndex == 1)
        {
            transform.position = Snake.previousPositon;
        }

        //Other indexes follow the body in front
        else
        {
            transform.position = snakeBodies[bodyIndex - 1].gameObject.GetComponent<SnakeBody>().previousPosition;
        }
    }

}
