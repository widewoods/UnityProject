using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthFirstSearch : MonoBehaviour
{
    public Vector2 startPos;
    Node startNode;

    public Vector2 endPos;
    Node endNode;

    List<Node> visited = new List<Node>();
    Stack<Node> stack = new Stack<Node>();

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            startNode = GridScript.grid[(int)startPos.x, (int)startPos.y];
            endNode = GridScript.grid[(int)endPos.x, (int)endPos.y];

            StartCoroutine(DFS(startNode, endNode));
        }
    }

    IEnumerator DFS(Node start, Node end)
    {
        stack.Clear();
        stack.Push(start);
        foreach(Node n in visited)
        {
            n.visited = false;
        }

        while(stack.Count != 0)
        {
            while(stack.Peek().visited)
            {
                stack.Pop();
                if(stack.Count == 0)
                {
                    Debug.LogWarning("Destination is out of reach!");
                    StopAllCoroutines();
                }
            }
            Node currentNode = stack.Pop();
            Debug.Log(currentNode.position);

            if (currentNode == end)
            {
                Debug.LogWarning("Destination Reached!");
                StopAllCoroutines();
            }

            currentNode.visited = true;
            visited.Add(currentNode);
            yield return new WaitForSeconds(0.001f);

            Node[] neighbors = FindNeighborNodes(currentNode);

            foreach (Node n in neighbors)
            {
                if (n.passable && !n.visited)
                {
                    stack.Push(n);
                }
            }
        }
    }

    Node[] FindNeighborNodes(Node node)
    {
        int posX = node.posX;
        int posY = node.posY;

        int up = posY + 1;
        int right = posX + 1;
        int down = posY - 1;
        int left = posX - 1;

        return new Node[4] { GridScript.grid[posX, up], GridScript.grid[right, posY], GridScript.grid[posX, down], GridScript.grid[left, posY] };
    }
}
