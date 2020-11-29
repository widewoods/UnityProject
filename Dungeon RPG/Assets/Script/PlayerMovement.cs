using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int horizontal = (int)Input.GetAxisRaw("Horizontal");
        int vertical = (int)Input.GetAxisRaw("Vertical");

        if(Mathf.Abs(horizontal) == 1)
        {
            Vector2 dir = Vector2.right * horizontal;
            transform.Translate(dir * Time.deltaTime * speed, Space.World);
        }
        if (Mathf.Abs(vertical) == 1)
        {
            Vector2 dir = Vector2.up * vertical;
            transform.Translate(dir * Time.deltaTime * speed, Space.World);
        }

        RotateToMouse();
    }

    void RotateToMouse()
    {
        Vector2 mousePositon = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float x = mousePositon.x - transform.position.x;
        float y = mousePositon.y - transform.position.y;

        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
