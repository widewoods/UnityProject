using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    Node node;
    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        node = GridScript.grid[(int)transform.position.x, (int)transform.position.y];
        if (!node.passable)
        {
            sprite.color = Color.black;
        }
        else if(node.state == 3)
        {
            sprite.color = Color.yellow;
        }
        else if (node.passable && node.visited)
        {
            sprite.color = Color.green;
        }
        else if (node.passable && node.state == 0)
        {
            sprite.color = Color.white;
        }
        else if(node.passable && node.state == 1)
        {
            sprite.color = Color.blue;
        }
        else if(node.passable && node.state == 2)
        {
            sprite.color = Color.red;
        }
    }
}
