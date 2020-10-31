using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public bool isFlipped;

    // Update is called once per frame
    void Update()
    {
        FollowMouse();

        if (Mathf.Abs(transform.rotation.z) >= 90)
        {
            Flip();
            Debug.Log("Flipped!");
        }
    }
    void Flip()
    {
        isFlipped = true;
        transform.Rotate(0f, 180f, 0f);
    }

    void FollowMouse()
    {
        //Get mouse position
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        //Get current position and compare with mouse position
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        //Calculate the angle and rotate
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
