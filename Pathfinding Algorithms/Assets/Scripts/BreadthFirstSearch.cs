using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadthFirstSearch : MonoBehaviour
{
    public Vector2 startPos;
    Node startNode;

    public Vector2 endPos;
    Node endNode;

    List<Node> visited = new List<Node>();
    Queue<Node> queue = new Queue<Node>();

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            startNode = GridScript.grid[(int)startPos.x, (int)startPos.y];
            endNode = GridScript.grid[(int)endPos.x, (int)endPos.y];

            StartCoroutine(BFS(startNode, endNode));
        }
    }

    IEnumerator BFS(Node start, Node end)
    {
        queue.Clear();
        queue.Enqueue(start);
        foreach (Node n in visited)
        {
            n.visited = false;
        }

        while (queue.Count != 0)
        {
            while (queue.Peek().visited)
            {
                queue.Dequeue();
                if (queue.Count == 0)
                {
                    Debug.LogWarning("Destination is out of reach!");
                    StopAllCoroutines();
                }
            }
            Node currentNode = queue.Dequeue();

            if (currentNode == end)
            {
                FindShortestPath(start, end);
                StopAllCoroutines();
            }

            currentNode.visited = true;
            visited.Add(currentNode);
            yield return null;

            Node[] neighbors = FindNeighborNodes(currentNode);

            foreach (Node n in neighbors)
            {
                if (n.passable && !n.visited)
                {
                    queue.Enqueue(n);
                }
            }
        }
    }

    void FindShortestPath(Node startNode, Node currentNode)
    {
        currentNode.state = 3;
        Node[] neighbors = FindNeighborNodes(currentNode);
        foreach(Node n in neighbors)
        {
            if(n == startNode)
            {
                n.state = 3;
                break;
            }
            if(n == currentNode.previousNode)
            {
                n.state = 3;
                FindShortestPath(startNode, n);
                break;
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

        Node[] neighbors = new Node[4] { GridScript.grid[posX, up], GridScript.grid[right, posY], GridScript.grid[posX, down], GridScript.grid[left, posY] };
        foreach(Node n in neighbors)
        {
            if(n.previousNode == null)
            {
                n.previousNode = node;
            }
        }


        return neighbors;
    }
}
