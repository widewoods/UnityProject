using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{

    public Transform firePoint;
    //public LineRenderer lineRenderer;


    public float distance = 10f;

    private Rigidbody2D rb;
    public GameObject player;
    private DistanceJoint2D joint;
    public LineRenderer lr; 

    private Vector2 direction;
    private Vector2 vector2Player;
    private RaycastHit2D hitInfo;

    public LayerMask mask;

    void Awake()
    {
        rb = player.GetComponent<Rigidbody2D>();
        joint = player.GetComponent<DistanceJoint2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            StartGrapple();
        }

        if (Input.GetButton("Fire2"))
        {
            DrawGrapple();
        }

        if (Input.GetButtonUp("Fire2"))
        {
            StopGrapple();

        }

    }

    void StartGrapple()
    {
        hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, distance, mask);

        if (hitInfo)
        {
            joint.enabled = true;

            joint.connectedAnchor = hitInfo.point;

            joint.distance = Vector2.Distance(player.transform.position, hitInfo.point);

        }

    }

    void StopGrapple()
    {
        joint.enabled = false;

        lr.enabled = false;
    }

    void DrawGrapple()
    {
        if (hitInfo)
        {

            lr.enabled = true;

            lr.SetPosition(0, firePoint.position);
            lr.SetPosition(1, hitInfo.point);
        }
    }
}
