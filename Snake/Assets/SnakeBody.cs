using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public static List<Transform> snakeBodies = new List<Transform>();

    public GameObject bodyParent;
    public static int bodyCount;
    float timer;

    public Vector2 previousPosition = Vector2.zero;

    [SerializeField]
    int bodyIndex;

    private void Awake()
    {
        timer = Snake.timer;
        bodyIndex = bodyCount + 1;
        bodyCount = bodyIndex;
        snakeBodies.Add(transform);

        //if(bodyIndex % 2 == 1)
        //{
        //    GetComponent<SpriteRenderer>().color = new Color(0.094f, 0.4f, 0.1f, 1);
        //}
    }

    private void Start()
    {
        bodyParent = GameObject.Find("SnakeBody");
        transform.parent = bodyParent.transform;
    }

    // Update is called once per frame
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
        previousPosition = transform.position;
        if(bodyIndex == 1)
        {
            transform.position = Snake.previousPositon;
        }
        else
        {
            transform.position = snakeBodies[bodyIndex - 1].gameObject.GetComponent<SnakeBody>().previousPosition;
        }
    }

}
