using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertionSort : MonoBehaviour
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
        for(int i = 1; i < array.Length; i++)
        {
            int j = i - 1;
            while(j >= 0 && (array[i] < array[j]))
            {
                j--;
                if(j == -1)
                {
                    break;
                }
            }
            int temp = array[i];
            for(int k = i; k > j + 1; k--)
            {
                array[k] = array[k - 1];
                yield return new WaitForSeconds(0.01f);
            }
            array[j + 1] = temp;
        }
    }
}
