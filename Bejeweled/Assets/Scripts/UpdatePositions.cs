using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePositions : MonoBehaviour
{
    public Vector2 position;

    JewelSpawner jewelSpawner;

    private void Start()
    {
        jewelSpawner = FindObjectOfType<JewelSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        position.x = Mathf.RoundToInt(transform.position.x);
        position.y = Mathf.RoundToInt(transform.position.y);

        UpdatePos(position, gameObject, jewelSpawner);
    }

    public static void UpdatePos(Vector2 position, GameObject gameObject, JewelSpawner jewelSpawner)
    {
        if (CheckSameType.columns[Mathf.RoundToInt(position.x)][Mathf.RoundToInt(position.y)] != gameObject)
        {
            CheckSameType.columns[Mathf.RoundToInt(position.x)][Mathf.RoundToInt(position.y)] = gameObject;
        }
    }
}
