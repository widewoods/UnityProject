using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject tempPrefab;
    public Vector2 position;

    public static void RemoveAtPos(Vector2 position, GameObject tempPrefab)
    {
        GameObject temp = Instantiate(tempPrefab, position, Quaternion.identity);
        Destroy(CheckSameType.columns[Mathf.RoundToInt(position.x)][Mathf.RoundToInt(position.y)]);
        CheckSameType.columns[Mathf.RoundToInt(position.x)][Mathf.RoundToInt(position.y)] = temp;
    }
}
