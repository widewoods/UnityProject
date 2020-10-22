using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    private Rigidbody2D rb;
    float mass;
    public float velocity;
    public float kineticEnergy;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        mass = rb.mass;
        //rb.velocity = new Vector2(-5f, 0f);
        //rb.AddForce(new Vector2(-20f, 0f), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        kineticEnergy = Mathf.Pow(velocity, 2)* mass * 0.5f;
        rb.velocity = new Vector2(velocity, 0f);
        
    }
}
