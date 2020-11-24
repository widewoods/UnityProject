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
        //RandomCellSpawn();
        StartCoroutine(RandomMazeSpawn());
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

    IEnumerator RandomMazeSpawn()
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
                n.passable = false;
                grid[i, j] = n;

                SpawnCell(i, j, n.passable);
            }
        }
        Stack<Node> stack = new Stack<Node>();

        stack.Push(grid[25, 25]);

        while(stack.Count != 0)
        {
            Node currentNode = stack.Pop();

            currentNode.passable = true;
            yield return null;

            Node[] neighbors = FindNeighbors(currentNode);

            foreach(Node n in neighbors)
            {
                while ((n.posX == 0) || (n.posX == 49) || (n.posY == 0) || (n.posY == 49))
                {
                    neighbors = FindNeighbors(currentNode);
                }
            }
            foreach(Node n in neighbors)
            {
                n.passable = true;
            }
            stack.Push(neighbors[neighbors.Length - 1]);
        }
    }

    Node[] FindNeighbors(Node node)
    {
        int posX = node.posX;
        int posY = node.posY;

        int randomSwitch = Random.Range(0, 4);
        int randomLength = Random.Range(1, 7);

        Node[] nodesToReturn = new Node[randomLength];

        switch (randomSwitch)
        {
            case 0:
                for(int i = 0; i < randomLength; i++)
                {
                    nodesToReturn[i] = grid[posX + i, posY];
                }
                break;
            case 1:
                for (int i = 0; i < randomLength; i++)
                {
                    nodesToReturn[i] = grid[posX - i, posY];
                }
                break;
            case 2:
                for (int i = 0; i < randomLength; i++)
                {
                    nodesToReturn[i] = grid[posX, posY + i];
                }
                break;
            case 3:
                for (int i = 0; i < randomLength; i++)
                {
                    nodesToReturn[i] = grid[posX, posY - i];
                }
                break;
        }
        return nodesToReturn;
    }
}
