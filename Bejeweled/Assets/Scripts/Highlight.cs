using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Jewel.firstClickedJewel != null)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            transform.position = Jewel.firstClickedJewel.position;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
