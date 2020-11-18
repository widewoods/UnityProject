using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelSpawner : MonoBehaviour
{
    public GameObject[] jewelsList = new GameObject[7];
    public GameObject jewelParent;
    public GameObject borderPrefab;
    public GameObject borderParent;
    CheckSameType check;

    // Start is called before the first frame update
    void Start()
    {
        borderParent = new GameObject("Borders");
        jewelParent = new GameObject("Jewels");
        check = FindObjectOfType<CheckSameType>();
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Initialize();
        }
    }

    void Initialize()
    {
        Destroy(jewelParent);
        Destroy(borderParent);
        jewelParent = new GameObject("Jewels");
        borderParent = new GameObject("Borders");
        for (int x = 0; x < 9; x++)
        {
            for(int y = 0; y < 9; y++)
            {
                int randomIndex = Random.Range(0, 7);
                GameObject jewel = Instantiate(jewelsList[randomIndex], new Vector2(x, y), Quaternion.identity, jewelParent.transform);
                jewel.GetComponent<Jewel>().type = randomIndex;
                CheckSameType.positionGameObjectPair[new Vector2(x,y)] = jewel;

                Instantiate(borderPrefab, new Vector2(x,y), Quaternion.identity, borderParent.transform);
            }
        }
    }
}
