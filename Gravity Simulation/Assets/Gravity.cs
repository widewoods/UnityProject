using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float planetMass;
    public float sunMass;

    public Vector3 initVelocity;

    public GameObject planet;
    public GameObject sun;

    public Rigidbody planetRb;
    public Rigidbody sunRb;

    float G = 6.67f * Mathf.Pow(10, -11);

    Vector3 planetPos;
    Vector3 sunPos;

    // Start is called before the first frame update
    void Start()
    {
        planetRb.AddForce(initVelocity, ForceMode.VelocityChange);
        planetRb.mass = planetMass;
        sunRb.mass = sunMass;
    }

    // Update is called once per frame
    void Update()
    {
        planetRb.AddForce(GetGravityForce(), ForceMode.Impulse);
        sunRb.AddForce(-GetGravityForce(), ForceMode.Impulse);
    }

    Vector3 GetGravityForce()
    {
        planetPos = planet.transform.position;
        sunPos = sun.transform.position;

        float distance = Vector3.Distance(planetPos, sunPos);
        float distanceSquared = distance * distance;

        float gravityMagnitude = G *  planetMass * sunMass / distanceSquared;

        Vector3 gravity = gravityMagnitude * (sunPos - planetPos);

        return gravity;
    }
}
