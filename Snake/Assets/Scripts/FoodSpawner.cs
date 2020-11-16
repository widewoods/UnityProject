using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public static int borderRadius = 12;
    List<Vector2> possibleSpawnPositions = new List<Vector2>();

    //Start with 1 food
    private void Start()
    {
        SpawnFood();
    }

    //Pick random position out of possible spawn positions nad instantiate food prefab
    public void SpawnFood()
    {
        FindPossibleSpawnPositions();
        Vector2 spawnPosition = possibleSpawnPositions[Random.Range(0, possibleSpawnPositions.Count + 1)];
        Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
    }

    void FindPossibleSpawnPositions()
    {
        //Reset list
        possibleSpawnPositions.RemoveRange(0, possibleSpawnPositions.Count);

        //Fill list from bottom left to top right position
        for (int x = -borderRadius; x <= borderRadius; x++)
        {
            for (int y = -borderRadius; y <= borderRadius; y++)
            {
                possibleSpawnPositions.Add(new Vector2(x, y));
            }
        }

        //Save indexes to remove and remove later
        //Messed with indexes if removed right away
        List<int> indexesToRemove = new List<int>();

        //Check for positions where snake body is and remove those positions
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

        //Remove index
        int count = 0;
        foreach (int elem in indexesToRemove)
        {
            possibleSpawnPositions.RemoveAt(elem + count);
            count--;
        }
    }
}
