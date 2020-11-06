using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float xRot;
    public float mouseSensitivity = 2f;

    // Update is called once per frame
    void Update()
    {
        xRot += Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.localEulerAngles = new Vector3(-xRot, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
