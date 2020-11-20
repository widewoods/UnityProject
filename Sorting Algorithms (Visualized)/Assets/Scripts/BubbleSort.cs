﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : MonoBehaviour
{
    int[] array;
    int comparisonCount;

    void Start()
    {
        array = RandomArray.randomArray;

        Sort();

        foreach (int item in array)
        {
            Debug.Log(item);
        }
        Debug.LogWarning("Bubble Sort Comparison Count: " + comparisonCount);
    }

    void Sort()
    {
        for(int j = array.Length - 1; j >= 1; j--)
        {
            for(int i = 0; i < j; i++)
            {
                if(array[i] > array[i + 1])
                {
                    int temp = array[i + 1];
                    array[i + 1] = array[i];
                    array[i] = temp;
                }
                comparisonCount++;
            }

        }
    }
}
