using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelSpawner : MonoBehaviour
{
    public GameObject[] jewels = new GameObject[7];
    public GameObject jewelParent;
    public GameObject borderPrefab;
    public GameObject borderParent;

    // Start is called before the first frame update
    void Start()
    {
        borderParent = new GameObject("Borders");
        jewelParent = new GameObject("Jewels");
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Initialize();
        }
    }

    void Initialize()
    {
        Destroy(jewelParent);
        jewelParent = new GameObject("Jewels");
        for(int x = 0; x < 9; x++)
        {
            for(int y = 0; y < 9; y++)
            {
                int randomIndex = Random.Range(0, 7);
                Instantiate(jewels[randomIndex], new Vector2(x, y), Quaternion.identity, jewelParent.transform);
                Instantiate(borderPrefab, new Vector2(x,y), Quaternion.identity, borderParent.transform);
            }
        }
    }
}
