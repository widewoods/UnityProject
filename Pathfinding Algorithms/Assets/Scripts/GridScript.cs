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
}
