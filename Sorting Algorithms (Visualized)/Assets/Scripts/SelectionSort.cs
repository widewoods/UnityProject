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

        StartCoroutine(Sort());

        //foreach (int item in array)
        //{
        //    Debug.Log(item);
        //}
    }

    public void SelectionSortStart()
    {
        if (DropDown.sortInt == 1)
        {
            StartCoroutine(Sort());
        }
    }

    IEnumerator Sort()
    {
        int[] array;
        array = RandomArray.randomArray;
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
                yield return new WaitForSeconds(0.005f);
            }
            temp = array[minIndex];
            array[minIndex] = array[j];
            array[j] = temp;
        }
    }

}
