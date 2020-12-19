using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule110 : CellularAutomaton
{
    Dictionary<(int, int, int), int> rules = new Dictionary<(int, int, int), int>();

    private void Start()
    {
        Initialize();
        cells[98].state = 1;
        InitializeRules();
        CreateHistory();

        InvokeRepeating("CheckNewState", 0, 0.3f);
        InvokeRepeating("CreateHistory", 0.01f, 0.3f);
    }

    void CheckNewState()
    {
        Cell left, center, right;

        for(int i = 1; i < cells.Length - 1; i++)
        {
            left = cells[i - 1];
            center = cells[i];
            right = cells[i + 1];

            (int, int, int) states =  (left.state, center.state, right.state);

            nextGenCells[i].state = rules[states];
        }

        for(int i = 0; i < cells.Length; i++)
        {
            cells[i].state = nextGenCells[i].state;
            nextGenCells[i].state = 0;
        } 
    }
    
    void InitializeRules()
    {
        rules.Add((1, 1, 1), 0);
        rules.Add(( 1, 1, 0 ), 1);
        rules.Add(( 1, 0, 1 ), 1);
        rules.Add(( 1, 0, 0 ), 0);
        rules.Add(( 0, 1, 1 ), 1);
        rules.Add(( 0, 1, 0 ), 1);
        rules.Add(( 0, 0, 1 ), 1);
        rules.Add(( 0, 0, 0 ), 0);
    }
}
