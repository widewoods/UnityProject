using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool grounded = true;

    public float jumpForce = 10f;
    public float sideForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(-11f, -3.42f);
    }

    private void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            transform.localScale = new Vector3(1f, 0.5f, 1f);
            transform.Translate(0f, -0.25f, 0f);
        }

        if (Input.GetKeyUp("s"))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            transform.Translate(0f, 0.25f, 0f);

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
  
        if (Input.GetKey("space") && grounded == true)
        {
            Jump(jumpForce);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-transform.right * sideForce);
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(transform.right * sideForce);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            grounded = true;
        }

        if (collision.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene("Platform");
            DeathCount.deathCount += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        transform.position = new Vector2(10.35f, -3.43f);

    }

    void Jump(float force)
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        grounded = false;
    }
}
