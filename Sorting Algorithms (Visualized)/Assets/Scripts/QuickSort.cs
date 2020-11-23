using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSort : MonoBehaviour
{
    int[] array;
    int comparisonCount;

    void Start()
    {
        array = RandomArray.randomArray;

        //foreach (int item in array)
        //{
        //    Debug.Log(item);
        //}
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(Sort(array, 0, array.Length - 1));
        }
    }

    IEnumerator Sort(int[] arr, int low, int high)
    { 
        if (low < high)
        {
            int temp;
            int pivot = arr[high];

            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                }
                yield return new WaitForSeconds(0.05f);
            }

            temp = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp;

            int k = i + 1;

            int partitionIndex = k;

            StartCoroutine(Sort(arr, low, partitionIndex - 1));
            StartCoroutine(Sort(arr, partitionIndex + 1, high));
        }
    }

    //int Partition(int[] arr, int low, int high)
    //{
    //    int temp;
    //    int pivot = arr[high];

    //    int i = low - 1;

    //    for (int j = low; j < high; j++)
    //    {
    //        if (array[j] < pivot)
    //        {
    //            i++;
    //            temp = arr[j];
    //            arr[j] = arr[i];
    //            arr[i] = temp;
    //        }
    //    }

    //    temp = arr[i + 1];
    //    arr[i + 1] = arr[high];
    //    arr[high] = temp;

    //    return i + 1;
    //}
}
