using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityCalculation : MonoBehaviour
{
    private static int momentum;

    public float startVelocity;

    static float wall_x = -8.5f;

    public int small_m, large_m;

    public static int collision = 0;

    public GameObject small_obj, large_obj;

    Block small;
    Block large;

    // Start is called before the first frame update
    void Start()
    {
        small = new Block(small_m, 0, small_obj);
        large = new Block(large_m, startVelocity, large_obj);

        large.rb.velocity = new Vector2(startVelocity, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckCollison();
    }

    void CheckCollison()
    {
        if(Mathf.Abs(small.obj.transform.position.x - large.obj.transform.position.x) <= 1.5f &&
           Mathf.Abs(small.obj.transform.position.x - large.obj.transform.position.x) >= 1.4f)
        {
            CalculateCollisions();
            small.rb.velocity = new Vector2(small.v, 0);
            large.rb.velocity = new Vector2(large.v, 0);
            collision++;
        }
        if(Mathf.Abs(wall_x - small.obj.transform.position.x) <= 0.5f)
        {
            Reverse(small);
            collision++;
        }
    }

    void CalculateCollisions()
    {
        float u1 = small.v;
        float u2 = large.v;
        float m1 = small.m;
        float m2 = large.m;
        float v1, v2;

        v1 = ((m1 - m2) / (m1 + m2) * u1) + (2 * m2 / (m1 + m2) * u2);

        v2 = (2 * m1 / (m1 + m2) * u1) + ((m2 - m1) / (m1 + m2) * u2);

        small.v = v1;
        large.v = v2;
    }

    void Reverse(Block block)
    {
        block.rb.velocity = -block.rb.velocity;
        block.v = -block.v;
    }
}

class Block
{
    public float m;
    public float v;
    public GameObject obj;
    public Rigidbody2D rb;

    public Block(float m, float v, GameObject obj)
    {
        this.m = m;
        this.v = v;
        this.obj = obj;
        rb = obj.GetComponent<Rigidbody2D>();
    }
}
