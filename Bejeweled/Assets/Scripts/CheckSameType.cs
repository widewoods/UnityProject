using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSameType : MonoBehaviour
{
    public static Dictionary<Vector2, GameObject> positionGameObjectPair = new Dictionary<Vector2, GameObject>();

    public Vector2 posToCheck;

    [SerializeField]
    int matchCount;

    private void Start()
    {
        matchCount = 1;
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

        if (Input.GetKeyDown(KeyCode.C))
        {
            MatchThree("Right", positionGameObjectPair[posToCheck]);
        }
    }

    public void MatchThree(string direction, GameObject obj)
    {
        GameObject objectToCheck;
        if(direction == "Right")
        {
            Vector2 checkPos = Vector2.right + new Vector2(obj.transform.position.x, obj.transform.position.y);
            if (positionGameObjectPair.ContainsKey(checkPos))
            {
                objectToCheck = positionGameObjectPair[checkPos];
                if(objectToCheck.GetComponent<Jewel>().type == obj.GetComponent<Jewel>().type)
                {
                    matchCount++;
                    if(matchCount == 3)
                    { 
                        for(int x = 0; x >= -2; x--)
                        {
                            GameObject matchObject = positionGameObjectPair[checkPos + new Vector2(x, 0)];
                            matchObject.GetComponent<Jewel>().RemoveAtPos(checkPos + new Vector2(x, 0));
                        }
                        matchCount = 1;
                    }
                    else
                    {
                        MatchThree("Right", positionGameObjectPair[checkPos]);
                    }
                }
            }
        }
    }
}
