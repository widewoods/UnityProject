using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePositions : MonoBehaviour
{
    public Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        if (Input.GetKeyDown(KeyCode.A))
        {
            UpdatePos();
        }
    }

    public void UpdatePos()
    {
        if(CheckSameType.positionGameObjectPair[position] != gameObject)
        {
            CheckSameType.positionGameObjectPair[position] = gameObject;
        }
    }
}
