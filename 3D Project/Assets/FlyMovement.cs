using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : MonoBehaviour
{
    public float rotateSpeed;
    public float curSpeed;
    public float maxSpeed;

    public Rigidbody rb;

    private void FixedUpdate()
    {
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePos.z = 10f;

        transform.Rotate(0f, (Input.mousePosition.x - Screen.width/2) * Time.deltaTime * rotateSpeed, 0f);
        transform.Rotate(-(Input.mousePosition.y - Screen.height / 2) * Time.deltaTime * rotateSpeed, 0f, 0f);
        

        if (Input.GetKey(KeyCode.W))
        {
            curSpeed += 0.1f;
            rb.velocity = transform.forward * curSpeed;
        }
    }
}
