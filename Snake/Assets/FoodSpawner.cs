using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public static int borderRadius = 12;
    List<Vector2> possibleSpawnPositions = new List<Vector2>();

    private void Start()
    {
        SpawnFood();
    }

    public void SpawnFood()
    {
        FindPossibleSpawnPositions();
        Vector2 spawnPosition = possibleSpawnPositions[Random.Range(0, possibleSpawnPositions.Count + 1)];
        Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
    }

    void FindPossibleSpawnPositions()
    {
        possibleSpawnPositions.RemoveRange(0, possibleSpawnPositions.Count);
        for (int x = -borderRadius; x <= borderRadius; x++)
        {
            for (int y = -borderRadius; y <= borderRadius; y++)
            {
                possibleSpawnPositions.Add(new Vector2(x, y));
            }
        }

        List<int> indexesToRemove = new List<int>();
        foreach(Vector2 possiblePosition in possibleSpawnPositions)
        {
            foreach (Transform occupiedPosition in SnakeBody.snakeBodies)
            {
                Vector2 position = new Vector2(occupiedPosition.position.x, occupiedPosition.position.y);
                if(possiblePosition == position)
                {
                    indexesToRemove.Add(possibleSpawnPositions.IndexOf(possiblePosition));
                }
            }
        }

        int count = 0;
        foreach (int elem in indexesToRemove)
        {
            possibleSpawnPositions.RemoveAt(elem + count);
            count--;
        }
    }
}
