using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizer : MonoBehaviour
{
    public static int[] array;
    public static int count;
    public int indexNum;

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

        //if(transform.localScale.y - 1 == indexNum)
        //{
        //    GetComponent<SpriteRenderer>().color = Color.green;
        //}
        //if(transform.localScale.y - 1 != indexNum)
        //{
        //    GetComponent<SpriteRenderer>().color = Color.red;
        //}
    }
}
