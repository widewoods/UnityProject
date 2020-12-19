using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellularAutomaton : MonoBehaviour
{
    public Cell[] cells;
    public Cell[] nextGenCells;

    public Sprite cellSprite;

    protected int historyCount = 0;

    protected int cellCount = 100;

    protected void Initialize()
    {
        cells = new Cell[cellCount];
        nextGenCells = new Cell[cellCount];

        for(int i = 0; i < cellCount; i++)
        {
            cells[i] = new Cell(0);
            nextGenCells[i] = new Cell(0);
        }
    }

    protected void CreateHistory()
    {
        historyCount++;

        for(int i = 0; i < cellCount; i++)
        {
            GameObject cell = new GameObject("Cell" + i);
            SpriteRenderer sprite = cell.AddComponent<SpriteRenderer>();

            cell.transform.position = new Vector3(i, -historyCount, 0);

            if(cells[i].state == 1)
            {
                sprite.color = Color.black;
            }
            else if(cells[i].state == 0)
            {
                sprite.color = Color.white;
            }

            sprite.sprite = cellSprite;
            cell.transform.localScale = Vector3.one * 1;
        }
    }
}
