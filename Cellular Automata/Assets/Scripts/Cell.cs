using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public int state;
    public float timeSinceDeath;

    public Cell(int setState)
    {
        state = setState;
    }
}
