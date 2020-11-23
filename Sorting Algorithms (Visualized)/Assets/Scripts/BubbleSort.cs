using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : MonoBehaviour
{
    int[] array;
    int comparisonCount;

    void Start()
    {
        array = RandomArray.randomArray;

        StartCoroutine(Sort());

        //foreach (int item in array)
        //{
        //    Debug.Log(item);
        //}
        //Debug.LogWarning("Bubble Sort Comparison Count: " + comparisonCount);
    }

    public void BubbleSortStart()
    {
        if(DropDown.sortInt == 0)
        {
            StartCoroutine(Sort());
        }
    }

    IEnumerator Sort()
    {
        int[] array;
        array = RandomArray.randomArray;
        for (int j = array.Length - 1; j >= 1; j--)
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
                yield return new WaitForSeconds(0.005f);
            }

        }
    }
}
