using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeValueChange : MonoBehaviour
{
    DepthFirstSearch DFS;
    BreadthFirstSearch BFS;

    // Start is called before the first frame update
    void Start()
    {
        DFS = FindObjectOfType<DepthFirstSearch>();
        BFS = FindObjectOfType<BreadthFirstSearch>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Node nodeToChange = GetNodeToChange();

            if (nodeToChange.passable)
            {
                nodeToChange.passable = false;
            }
            else
            {
                nodeToChange.passable = true;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Node nodeToChange = GetNodeToChange();

            SetStartPos(nodeToChange);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Node nodeToChange = GetNodeToChange();

            SetEndPos(nodeToChange);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            ResetNodeState();
        }
    }

    Node GetNodeToChange()
    {
        int posX = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
        int posY = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        return GridScript.grid[posX, posY];
    }

    void ResetNodeState()
    {
        foreach(Node n in GridScript.grid)
        {
            n.state = 0;
        }
    }

    void SetStartPos(Node node)
    {
        node.state = 1;
        if (DFS)
        {
            DFS.startPos = node.position;
        }
        if (BFS)
        {
            BFS.startPos = node.position;
        }
    }

    void SetEndPos(Node node)
    {
        node.state = 2;
        if (DFS)
        {
            DFS.endPos = node.position;
        }
        if (BFS)
        {
            BFS.endPos = node.position;
        }
    }
}
