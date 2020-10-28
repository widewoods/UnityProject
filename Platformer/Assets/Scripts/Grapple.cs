using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{

    public Transform firePoint;
    public LineRenderer lineRenderer;
    
    public float pullSpeed = 10f;

    private Rigidbody2D rb;
    public GameObject player;

    private Vector2 direction;
    private Vector2 vector2Player;

    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(ShootGrapple());
        }

    }

    IEnumerator ShootGrapple()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            Vector2 currentLinePoint = hitInfo.point * 0.1f;

            for(float i = 0f; i < 1.1f; i += 0.1f)
            {
                //Render a line from the firepoint to the hitpoint
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, currentLinePoint);

                currentLinePoint = hitInfo.point * i;

                yield return new WaitForSeconds(0.01f);
            }
            

            vector2Player = new Vector2(player.transform.position.x, player.transform.position.y);

            //Calculate the direction to move in
            direction = hitInfo.point - vector2Player;

            //Add an impulse force towards the hitpoint
            //rb.AddForce(direction.normalized * pullSpeed, ForceMode2D.Impulse);

            rb.velocity = direction.normalized * pullSpeed;

            //lineRenderer.enabled = true;

            yield return new WaitForSeconds(0.1f);

            //lineRenderer.enabled = false;

        }

    }
}
