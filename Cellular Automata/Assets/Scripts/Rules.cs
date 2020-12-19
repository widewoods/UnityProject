using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : CellularAutomaton
{
    Dictionary<(int, int, int), int> rules = new Dictionary<(int, int, int), int>();

    int[] ruleSet = new int[8];

    private void Start()
    {
        Initialize();
        cells[99].state = 1;

        //Rule 110
        ruleSet = new int[8] { 0, 1, 1, 0, 1, 1, 1, 0 };

        //RandomRuleSet
        //for(int i = 0; i < 8; i++)
        //{
        //    ruleSet[i] = Random.Range(0, 2);
        //}

        InitializeRules(ruleSet);
        CreateHistory();

        InvokeRepeating("CheckNewState", 0, 0.1f);
        InvokeRepeating("CreateHistory", 0.01f, 0.1f);
    }

    void CheckNewState()
    {
        Cell left, center, right;

        for(int i = 0; i < cells.Length; i++)
        {
            if(i == 0)
            {
                left = cells[cells.Length - 1];
                center = cells[i];
                right = cells[i + 1];
            }
            else if(i == cells.Length - 1)
            {
                left = cells[i - 1];
                center = cells[i];
                right = cells[0];
            }
            else
            {
                left = cells[i - 1];
                center = cells[i];
                right = cells[i + 1];
            }

            (int, int, int) states =  (left.state, center.state, right.state);

            nextGenCells[i].state = rules[states];
        }

        for(int i = 0; i < cells.Length; i++)
        {
            cells[i].state = nextGenCells[i].state;
            nextGenCells[i].state = 0;
        }

        //Clear and Repeat with random rules when reaching 57th gen

        //if (historyCount == 57)
        //{
        //    Destroy(cellContainer);
        //    Initialize();

        //    for(int i = 0; i < cells.Length; i++)
        //    {
        //        if(Random.Range(0, 11) < 3)
        //        {
        //            cells[i].state = 1;
        //        }
        //    }

        //    for (int i = 0; i < 8; i++)
        //    {
        //        ruleSet[i] = Random.Range(0, 2);
        //    }
        //    rules.Clear();
        //    InitializeRules(ruleSet);
        //    CreateHistory();

        //    CancelInvoke();

        //    InvokeRepeating("CheckNewState", 0, 0.1f);
        //    InvokeRepeating("CreateHistory", 0.01f, 0.1f);
        //}
    }
    
    void InitializeRules(int[] ruleSet)
    {
        rules.Add((1, 1, 1), ruleSet[0]);
        rules.Add(( 1, 1, 0 ), ruleSet[1]);
        rules.Add(( 1, 0, 1 ), ruleSet[2]);
        rules.Add(( 1, 0, 0 ), ruleSet[3]);
        rules.Add(( 0, 1, 1 ), ruleSet[4]);
        rules.Add(( 0, 1, 0 ), ruleSet[5]);
        rules.Add(( 0, 0, 1 ), ruleSet[6]);
        rules.Add(( 0, 0, 0 ), ruleSet[7]);
    }
}
