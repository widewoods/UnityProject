using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpHeight;
    public float moveSpeed;
    bool grounded = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector2(moveSpeed, 0f));
        
    }

    private void Update()
    {
        if (Input.GetKey("space") && grounded == true)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(-0.3f, jumpHeight);
        //rb.AddForce
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Collision")
        {
            grounded = true;
        }
    }
}
