using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector2 position;
    public int posX;
    public int posY;

    public bool visited;
    public bool passable;

    public int state;

    public Node previousNode;
}

