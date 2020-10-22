using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public GameObject c1;
    public GameObject c2;
    private Rigidbody2D rb1;
    private Rigidbody2D rb2;
    private float m1;
    private float m2;
    private float radius;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
        rb1 = c1.GetComponent<Rigidbody2D>();
        rb2 = c2.GetComponent<Rigidbody2D>();
        m1 = rb1.mass;
        m2 = rb2.mass;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        radius = Mathf.Sqrt(Mathf.Pow(c1.transform.position.x - c2.transform.position.x, 2) + Mathf.Pow(c1.transform.position.y - c2.transform.position.y, 2));
        direction = (c2.transform.position - c1.transform.position).normalized;
        rb1.velocity = direction * m1 * m2  / Mathf.Pow(radius, 2);
    }
}
