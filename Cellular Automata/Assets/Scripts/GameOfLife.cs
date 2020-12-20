using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOfLife : MonoBehaviour
{
    public Cell[,] cells;
    public Cell[,] nextGenCells;

    public Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;

    public float cellUpdateTimer = 0.3f;

    private GameObject cellContainer;

    public Sprite cellSprite;

    public int cellCount = 50;

    void Initialize()
    {
        cellContainer = new GameObject("cellContainer");

        cells = new Cell[cellCount, cellCount];
        nextGenCells = new Cell[cellCount, cellCount];

        for(int i = 0; i < cellCount; i++)
        {
            for(int j = 0; j < cellCount; j++)
            {
                cells[i, j] = new Cell(0);
                nextGenCells[i, j] = new Cell(0);
            }
        }

        CreateVisuals();
    }

    int GetAliveNeighborCount(int x, int y)
    {
        Cell TL, TC, TR, L, R, BL, BC, BR;
        int right = x + 1, left = x - 1, top = y + 1, bottom = y - 1;

        if(x == cellCount - 1)
        {
            right = 0;
        }
        if(x == 0)
        {
            left = cellCount - 1;
        }
        if(y == cellCount - 1)
        {
            top = 0;
        }
        if(y == 0)
        {
            bottom = cellCount - 1;
        }

        TL = cells[left, top];
        TC = cells[x, top];
        TR = cells[right, top];
        L = cells[left, y];
        R = cells[right, y];
        BL = cells[left, bottom];
        BC = cells[x, bottom];
        BR = cells[right, bottom];

        Cell[] neighbors = new Cell[8] { TL, TC, TR, L, R, BL, BC, BR };

        int aliveNeighborCount = 0;
        foreach(Cell cell in neighbors)
        {
            if(cell.state == 1)
            {
                aliveNeighborCount++;
            }
        }

        return aliveNeighborCount;
    }

    void GetNextGeneration()
    {
        for(int x = 0; x < cellCount; x++)
        {
            for (int y = 0; y < cellCount; y++)
            {
                int aliveNeighborCount = GetAliveNeighborCount(x, y);

                if (cells[x, y].state == 1)
                {
                    if ((aliveNeighborCount == 2 )|| (aliveNeighborCount == 3))
                    {
                        nextGenCells[x, y].state = 1;
                    }
                    else
                    {
                        nextGenCells[x, y].state = 0;
                    }
                }
                else
                {
                    if(aliveNeighborCount == 3)
                    {
                        nextGenCells[x, y].state = 1;
                    }
                }
            }
        }

        for(int x = 0; x < cellCount; x++)
        {
            for(int y = 0; y < cellCount; y++)
            {
                cells[x, y].state = nextGenCells[x, y].state;
                nextGenCells[x, y].state = 0;
            }
        }
    }

    void CreateVisuals()
    {
        for (int x = 0; x < cellCount; x++)
        {
            for (int y = 0; y < cellCount; y++)
            {
                GameObject cell = new GameObject("Cell");
                cell.transform.parent = cellContainer.transform;

                SpriteRenderer sprite = cell.AddComponent<SpriteRenderer>();
                GameOfLifeVisual visual = cell.AddComponent<GameOfLifeVisual>();

                visual.x = x;
                visual.y = y;

                sprite.sprite = cellSprite;

                cell.transform.position = new Vector3(x, y, 0);
            }
        }
    }

    void GenerateStartingStates()
    {
        for (int x = 1; x < cellCount - 1; x++)
        {
            for (int y = 1; y < cellCount - 1; y++)
            {
                //Random
                if (Random.Range(0, 11) < 3)
                {
                    cells[x, y].state = 1;
                }

                //if (y < 25 && y % 2 == 0)
                //{
                //    cells[x, y].state = 1;
                //}
            }
        }
    }

    private void Start()
    {
        Initialize();
        GenerateStartingStates();

        gradient = new Gradient();

        colorKey = new GradientColorKey[2];
        Color color1, color2;
        ColorUtility.TryParseHtmlString("#CC22EA", out color1);
        ColorUtility.TryParseHtmlString("#482AC2", out color2);

        colorKey[0].color = color1;
        colorKey[0].time = 0.0f;
        colorKey[1].color = color2;
        colorKey[1].time = 1.0f;

        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);

        InvokeRepeating("GetNextGeneration", 0, cellUpdateTimer);
    }
}
