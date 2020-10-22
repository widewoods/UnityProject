using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public Rigidbody2D rb;
    public float magnitude;
    private void FixedUpdate()
    {
        Vector2 force = new Vector2(0f, 1f) * magnitude;
        rb.AddForce(force);
    }

    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            this.enabled = false;
        }
    }
}
 