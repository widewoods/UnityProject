using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public static Node[,] grid;

    public int rowCount;
    public int columnCount;

    public float wallProbability;

    public Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        RandomCellSpawn();
        //StartCoroutine(RandomMazeSpawn());
    }

    void RandomCellSpawn()
    {
        grid = new Node[rowCount, columnCount];
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                Node n = new Node();
                n.position = new Vector2(i, j);
                n.posX = i;
                n.posY = j;
                n.passable = Random.Range(0f, 1f) >= wallProbability;
                grid[i, j] = n;

                SpawnCell(i, j, n.passable);
            }
        }
        SetBorder();
    }

    void SetBorder()
    {
        for(int i = 0; i < rowCount; i++)
        {
            grid[i, 0].passable = false;
            grid[i, rowCount - 1].passable = false;
            grid[0, i].passable = false;
            grid[columnCount - 1, i].passable = false;
        }
    }

    void SpawnCell(int x, int y, bool state)
    {
        GameObject g = new GameObject("X: " + x + " Y: " + y);
        g.AddComponent<Cell>();
        g.transform.position = new Vector3(x, y);
        SpriteRenderer s = g.AddComponent<SpriteRenderer>();
        s.sprite = sprite;
    }

    //IEnumerator RandomMazeSpawn()
    //{
    //    Stack<Node> stack = new Stack<Node>();
    //    grid = new Node[rowCount, columnCount];
    //    for (int i = 0; i < rowCount; i++)
    //    {
    //        for (int j = 0; j < columnCount; j++)
    //        {
    //            Node n = new Node();
    //            n.position = new Vector2(i, j);
    //            n.posX = i;
    //            n.posY = j;
    //            n.passable = false;
    //            grid[i, j] = n;

    //            SpawnCell(i, j, n.passable);
    //        }
    //    }

    //    stack.Push(grid[25, 25]);

    //    while (stack.Count != 0)
    //    {
    //        Node currentNode = stack.Pop();

    //        currentNode.passable = true;
    //        yield return null;

    //        Node[] neighbors = new Node[4] { FindRandomNeighbor(currentNode), FindRandomNeighbor(currentNode), FindRandomNeighbor(currentNode), FindRandomNeighbor(currentNode) };

    //        foreach(Node n in neighbors)
    //        {
    //            while ((n.posX == 0) || (n.posX == 49) || (n.posY == 0) || (n.posY == 49))
    //            {
    //                stack.Push(grid[25, 25]);
    //                neighbors = new Node[1] { stack.Pop() };
    //            }
    //            if (CheckDiggable(n))
    //            {
    //                stack.Push(n);
    //            }
    //        }
    //    }
    //}

    //Node FindRandomNeighbor(Node node)
    //{
    //    int posX = node.posX;
    //    int posY = node.posY;

    //    int up = posY + 1;
    //    int right = posX + 1;
    //    int down = posY - 1;
    //    int left = posX - 1;

    //    int randomSwitch = Random.Range(0, 4);

    //    Node nodeToReturn = null;

    //    switch (randomSwitch)
    //    {
    //        case 0:
    //            nodeToReturn = grid[posX, up];
    //            break;
    //        case 1:
    //            nodeToReturn = grid[right, posY];
    //            break;
    //        case 2:
    //            nodeToReturn = grid[posX, down];
    //            break;
    //        case 3:
    //            nodeToReturn = grid[left, posY];
    //            break;
    //    }
    //    return nodeToReturn;
    //}

    //Node[] FindAllNeighbors(Node node)
    //{
    //    int posX = node.posX;
    //    int posY = node.posY;

    //    int up = posY + 1;
    //    int right = posX + 1;
    //    int down = posY - 1;
    //    int left = posX - 1;

    //    int randomSwitch = Random.Range(0, 4);

    //    Node[] nodesToReturn = new Node[4] { grid[posX, up], grid[right, posY], grid[posX, down], grid[left, posY] };
    //    return nodesToReturn;
    //}

    //bool CheckDiggable(Node neighbor)
    //{
    //    Node[] neighborsOfNeighbor = FindAllNeighbors(neighbor);

    //    int adjacentImpassableCount = 0;
    //    foreach (Node n in neighborsOfNeighbor)
    //    {
    //        if (!n.passable)
    //        {
    //            adjacentImpassableCount++;
    //        }
    //    }
    //    if (adjacentImpassableCount >= 3)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
}
