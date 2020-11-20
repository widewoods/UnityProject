using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelSpawner : MonoBehaviour
{
    public GameObject[] jewelsList = new GameObject[7];
    public GameObject[] particleList = new GameObject[7];
    public GameObject jewelParent;
    public GameObject borderPrefab;
    public GameObject borderParent;

    GameObject temp;

    // Start is called before the first frame update
    void Awake()
    {
        borderParent = new GameObject("Borders");
        jewelParent = new GameObject("Jewels");
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Initialize();
        }
        temp = GameObject.FindGameObjectWithTag("Temp");
        if (temp)
        {
            SpawnNewJewel(temp);
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
            CheckSameType.columns.Add(new List<GameObject>());
            for(int y = 0; y < 10; y++)
            {
                int randomIndex = Random.Range(0, 7);
                GameObject jewel = Instantiate(jewelsList[randomIndex], new Vector2(x, y), Quaternion.identity, jewelParent.transform);
                jewel.GetComponent<Jewel>().type = randomIndex;
                jewel.GetComponent<Jewel>().particle = particleList[randomIndex];

                CheckSameType.columns[x].Add(jewel);

                Instantiate(borderPrefab, new Vector2(x,y), Quaternion.identity, borderParent.transform);
            }
        }
    }

    void SpawnNewJewel(GameObject obj)
    {
        if (obj.transform.position.y == 9)
        {
            Destroy(obj);
            int randomIndex = Random.Range(0, 7);
            Destroy(CheckSameType.columns[Mathf.RoundToInt(obj.transform.position.x)][Mathf.RoundToInt(obj.transform.position.y)]);
            GameObject jewel = Instantiate(jewelsList[randomIndex], obj.transform.position, Quaternion.identity, jewelParent.transform);
            jewel.GetComponent<Jewel>().type = randomIndex;

            CheckSameType.columns[Mathf.RoundToInt(obj.transform.position.x)][Mathf.RoundToInt(obj.transform.position.y)] = jewel;
        }
        
    }
}

