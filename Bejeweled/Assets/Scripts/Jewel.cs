using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewel : MonoBehaviour
{
    Vector2 mouseClickPosition;
    Vector2 position;

    public Vector2 positionToRemove;

    CheckSameType check;

    public static Transform firstClickedJewel;
    public static Transform secondClickedJewel;

    public static List<GameObject> temps = new List<GameObject>();
    public GameObject tempPrefab;

    public GameObject particle;

    public int type;

    public int posX;
    public int posY;

    // Start is called before the first frame update
    void Start()
    {
        check = FindObjectOfType<CheckSameType>();
        position = transform.position;
        ResetClickedJewels();
        posX = Mathf.RoundToInt(transform.position.x);
        posY = Mathf.RoundToInt(transform.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Fall();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SwapPlaces();
        }
        posX = Mathf.RoundToInt(transform.position.x);
        posY = Mathf.RoundToInt(transform.position.y);
    }

    void SwapPlaces()
    {
        mouseClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 displacement = (new Vector2(transform.position.x, transform.position.y) - mouseClickPosition);

        if (displacement.magnitude < 0.5f)
        {
            if (firstClickedJewel == null && firstClickedJewel != transform)
            {
                firstClickedJewel = transform;
            }
            else if (firstClickedJewel != null && firstClickedJewel == transform)
            {
                ResetClickedJewels();
            }
            else if (firstClickedJewel != null && firstClickedJewel != transform)
            {
                secondClickedJewel = transform;
                if ((firstClickedJewel.position - secondClickedJewel.position).magnitude <= 1.1f)
                {
                    Vector3 direction = (secondClickedJewel.position - firstClickedJewel.position).normalized;
                    StartCoroutine(AnimateTranslate(firstClickedJewel, direction));
                    StartCoroutine(AnimateTranslate(secondClickedJewel, -direction));
                    ResetClickedJewels();
                    StartCoroutine(check.MatchAll());
                }
                else
                {
                    ResetClickedJewels();
                }
            }
        }
    }

    void ResetClickedJewels()
    {
        firstClickedJewel = null;
        secondClickedJewel = null;
    }

    IEnumerator AnimateTranslate(Transform transform, Vector2 direction)
    {
        if (transform)
        {
            for (int i = 0; i <= 9; i++)
            {
                transform.Translate(direction.normalized / 10);
                yield return new WaitForSeconds(0.01f);
            }
        }

        RoundPositionToInt();
    }

    public void Fall()
    {
        if (transform.position.y >= 1)
        {
            
            if(!CheckSameType.columns[posX][posY - 1])
            {
                GameObject temp = Instantiate(tempPrefab, position + Vector2.down, Quaternion.identity);
                CheckSameType.columns[posX][posY - 1] = temp;
            }
            if (CheckSameType.columns[posX][posY - 1].CompareTag("Temp"))
            {
                GameObject temp = Instantiate(tempPrefab, position, Quaternion.identity);
                CheckSameType.columns[posX][posY] = temp;
                Destroy(CheckSameType.columns[posX][posY -1]);
                CheckSameType.columns[posX][posY -1] = gameObject;

                gameObject.transform.Translate(Vector2.down);
                RoundPositionToInt();
            }
        }
    }

    void RoundPositionToInt()
    {
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), 0);
        position = transform.position;
    }
}
