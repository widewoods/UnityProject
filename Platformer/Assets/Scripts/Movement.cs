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
        rb.drag = 1;
    }

    private void Update()
    {

        if (Input.GetKeyDown("space") && grounded == true)
        {
            Jump(jumpForce);

            FindObjectOfType<SoundManager>().Play("JumpSound");
        }
    }

    private void FixedUpdate()
    {
        
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
        //if (collision.gameObject.tag == "platform")
        //{
        //    grounded = true;
        //}

        if (collision.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            DeathCount.deathCount += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
    }

    void Jump(float force)
    {
        rb.velocity = (transform.up * jumpForce);
        grounded = false;
    }

}
