﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomArray : MonoBehaviour
{
    public static int[] randomArray;
    public int itemCount;
    public GameObject visualizerPrefab;

    void Awake()
    {
        randomArray = new int[itemCount];

        GameObject visualizerParent = new GameObject("VisualizerParent");

        //Add integers from 1 to item count
        for(int i = 1; i <= itemCount; i++)
        {
            randomArray[i - 1] = i;
            Instantiate(visualizerPrefab, visualizerParent.transform);
        }

        Shuffle(randomArray);
    }

    public static void Shuffle(int[] array)
    {
        for(int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    //public static bool IsSorted(int[] array)
    //{
    //    for(int i = 0; i < array.Length - 1; i++)
    //    {
    //        if(array[i] < array[i + 1])
    //        {
    //            return false;
    //        }
    //    }
    //    return true;
    //}
}
