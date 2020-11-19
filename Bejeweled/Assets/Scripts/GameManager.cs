using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static List<GameObject> jewels = new List<GameObject>();
    CheckSameType checkSameType;

    Vector2 position;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            UpdateAll();
        }
    }

    public static void UpdateAll()
    {
        for (int x = 0; x < 9; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                Vector2 position = new Vector2(x, y);
                jewels.Add(CheckSameType.positionGameObjectPair[position]);
            }
        }

        foreach(GameObject jewel in jewels)
        {
            if(jewel.TryGetComponent(out Jewel jewelComponent))
            {
                jewelComponent.Fall();
            }
        }

        foreach (GameObject temp in Jewel.temps)
        {
            if (temp)
            {
                Destroy(temp);
                CheckSameType.positionGameObjectPair[temp.transform.position] = null;
            }
        }
    }
}
