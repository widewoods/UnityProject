using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    int[] array;

    private void Update()
    {
        AdjustPosition();
    }

    // Start is called before the first frame update
    void AdjustPosition()
    {
        array = RandomArray.randomArray;
        transform.position = new Vector3(array.Length/2 , array.Length/2 - 0.5f, -10);
        Camera.main.orthographicSize = array.Length/2;
    }
}
