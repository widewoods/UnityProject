using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticEnergyConservation : MonoBehaviour
{
    public float StartV;
    public Rigidbody2D rb1;
    public Rigidbody2D rb2;
    float velocity1;
    float velocity2;
    float mass1;
    float mass2;
    float kineticE;
    // Start is called before the first frame update
    void Start()
    {
        mass1 = rb1.mass;
        mass2 = rb2.mass;
        kineticE = 0.5f * mass1 * Mathf.Pow(StartV, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
