using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSort : MonoBehaviour
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
        Debug.LogWarning("Selection Sort Comparison Count: " + comparisonCount);
    }

    void Sort()
    {
        int min;
        int minIndex;
        int temp;
        for(int j = 0; j < array.Length - 1; j++)
        {
            min = array[j];
            minIndex = j;
            for(int i = j + 1; i < array.Length; i++)
            {
                if(array[i] < min)
                {
                    minIndex = i;
                    min = array[i];
                }
                comparisonCount++;
            }
            temp = array[minIndex];
            array[minIndex] = array[j];
            array[j] = temp;
        }
    }

}
