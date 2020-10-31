using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isGrounded = true;

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

        if (Input.GetKeyDown("space") && isGrounded == true)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }

    void Jump(float force)
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

}
