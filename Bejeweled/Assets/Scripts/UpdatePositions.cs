using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePositions : MonoBehaviour
{
    public Vector2 position;

    // Update is called once per frame
    void Update()
    {
        position.x = Mathf.RoundToInt(transform.position.x);
        position.y = Mathf.RoundToInt(transform.position.y);
        UpdatePos(position, gameObject);
    }

    public static void UpdatePos(Vector2 position, GameObject gameObject)
    {
        //if (CheckSameType.positionGameObjectPair[position] != gameObject)
        //{
        //    CheckSameType.positionGameObjectPair[position] = gameObject;
        //}
    }
}
