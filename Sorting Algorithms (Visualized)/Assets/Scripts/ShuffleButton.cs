using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShuffleButton : MonoBehaviour
{
    public Slider countSlider;

    public void Shuffle()
    {
        int itemCount = (int)countSlider.value;
        RandomArray.randomArray = new int[itemCount];
        int[] array = RandomArray.randomArray;
        GameObject visualizerPrefab = (GameObject)Resources.Load("Visualizer");

        Destroy(GameObject.Find("VisualizerParent"));

        GameObject visualizerParent = new GameObject("VisualizerParent");

        Visualizer.array = array;
        Visualizer.count = 0;

        //Add integers from 1 to item count
        for (int i = 1; i <= itemCount; i++)
        {
            array[i - 1] = i;
            Instantiate(visualizerPrefab, visualizerParent.transform);
        }

        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
