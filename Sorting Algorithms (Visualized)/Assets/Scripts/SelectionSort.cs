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

    IEnumerator Sort()
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
                yield return new WaitForSeconds(0.01f);
            }
            temp = array[minIndex];
            array[minIndex] = array[j];
            array[j] = temp;
        }
    }

}
