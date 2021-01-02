using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMultiple : MonoBehaviour
{
    public static float G = 6.67f * Mathf.Pow(10, -11);

    public Vector3 initialVelocity;

    public float mass;

    Rigidbody rb;

    GravityMultiple[] objects;

    private void Start()
    {

        objects = FindObjectsOfType<GravityMultiple>();
        rb = GetComponent<Rigidbody>();

        rb.mass = mass;

        rb.AddForce(initialVelocity, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach(GravityMultiple obj in objects)
        {
            if (obj != this)
            {
                rb.AddForce(GetGravityForce(this, obj) * 0.1f, ForceMode.Impulse);
            }
        }
    }

    Vector3 GetGravityForce(GravityMultiple obj1, GravityMultiple obj2)
    {
        Vector3 obj1Pos = obj1.gameObject.transform.position;
        Vector3 obj2Pos = obj2.gameObject.transform.position;

        float distance = Vector3.Distance(obj1Pos, obj2Pos);
        float distanceSquared = distance * distance;

        float gravityMagnitude = G * obj1.mass * obj2.mass / distanceSquared;

        Vector3 gravity = gravityMagnitude * (obj2Pos - obj1Pos);

        return gravity;
    }
}
