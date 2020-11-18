using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSameType : MonoBehaviour
{
    public static Dictionary<Vector2, GameObject> positionGameObjectPair = new Dictionary<Vector2, GameObject>();

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    Debug.Log(positionGameObjectPair[new Vector2(x, y)]);
                }
            }
        }
    }

    //void CheckForSameType(string direction, GameObject obj)
    //{
    //    GameObject objectToCheck;
    //    switch (direction)
    //    {
    //        case "up":
    //            if (obj.transform.position.y < 7.9f)
    //            {
    //                Vector2 checkPos = new Vector2(0, 1) + new Vector2(obj.transform.position.x, obj.transform.position.y);
    //                objectToCheck = positionGameObjectPair[checkPos];

    //                Check(objectToCheck, checkPos, obj, direction);
    //            }
    //            break;
    //        case "down":
    //            if (obj.transform.position.y > 0.1f)
    //            {
    //                Vector2 checkPos = new Vector2(0, -1) + new Vector2(obj.transform.position.x, obj.transform.position.y);
    //                objectToCheck = positionGameObjectPair[checkPos];

    //                Check(objectToCheck, checkPos, obj, direction);
    //            }
    //            break;
    //        case "right":
    //            if (obj.transform.position.x < 7.9f)
    //            {
    //                Vector2 checkPos = new Vector2(1, 0) + new Vector2(obj.transform.position.x, obj.transform.position.y);
    //                objectToCheck = positionGameObjectPair[checkPos];

    //                Check(objectToCheck, checkPos, obj, direction);
    //            }
    //            break;
    //        case "left":
    //            if(obj.transform.position.x > 0.1f)
    //            {
    //                Vector2 checkPos = new Vector2(-1, 0) + new Vector2(obj.transform.position.x, obj.transform.position.y);
    //                objectToCheck = positionGameObjectPair[checkPos];

    //                Check(objectToCheck, checkPos, obj, direction);
    //            }
    //            break;
    //    }
    //}

    //void CheckAllJewels(string direction)
    //{
    //    for (int x = 0; x < 9; x++)
    //    {
    //        for (int y = 0; y < 9; y++)
    //        {
    //            CheckForSameType(direction, positionGameObjectPair[new Vector2(x, y)]);
    //        }
    //    }
    //}

    //void Check(GameObject objectToCheck, Vector2 checkPos, GameObject obj, string direction)
    //{
    //    if (objectToCheck)
    //    {
    //        if (obj.GetComponent<Jewel>().type == objectToCheck.GetComponent<Jewel>().type)
    //        {
    //            //positionGameObjectPair.Remove(checkPos);
    //            Destroy(objectToCheck);
    //        }
    //    }
    //}
}
