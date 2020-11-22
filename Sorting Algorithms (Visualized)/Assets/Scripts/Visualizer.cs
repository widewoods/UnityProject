using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizer : MonoBehaviour
{
    int[] array;
    static int count;
    int indexNum;

    // Start is called before the first frame update
    void Awake()
    {
        indexNum = count;
        count++;
        
    }

    private void Start()
    {
        array = RandomArray.randomArray;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(1, array[indexNum], 1);
        transform.position = new Vector2(indexNum, (transform.localScale.y - 1)/ 2);
    }
}
