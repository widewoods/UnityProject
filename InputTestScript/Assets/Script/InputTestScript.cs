using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTestScript : MonoBehaviour
{
    float h, v;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //-1f ~ 1f float값a
        //h = Input.GetAxis("Horizontal");
        //v = Input.GetAxis("Vertical");
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        //print("h = " + h + ", v = " + v);

        if(Input.GetKeyDown(KeyCode.A))
        {
            print("Down");
        }
        if (Input.GetKey(KeyCode.A))
        {
            print("Key");
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            print("Up");
        }
        if (Input.GetMouseButtonDown(0))
        {
            print("MouseDown");
        }
        if (Input.GetMouseButton(0))
        {
            print("Mouse");
        }
        if (Input.GetMouseButtonUp(0))
        {
            print("MouseUp");
        }
    }
}
