using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewel : MonoBehaviour
{
    Vector2 mouseClickPosition;
    Vector2 position;

    public static Transform firstClickedJewel;
    public static Transform secondClickedJewel;

    public int type;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        ResetClickedJewels();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SwapPlaces();
            //Fall();
        }
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
                if((firstClickedJewel.position - secondClickedJewel.position).magnitude <= 1.1f)
                {
                    Vector3 direction = (secondClickedJewel.position - firstClickedJewel.position).normalized;
                    StartCoroutine(AnimateTranslate(firstClickedJewel, direction));
                    StartCoroutine(AnimateTranslate(secondClickedJewel, -direction));
                    ResetClickedJewels();
                    Debug.Log("Swapped");
                }
                else
                {
                    ResetClickedJewels();
                    Debug.Log("Too Far");
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
        for(int i = 0; i <= 9; i++)
        {
            transform.Translate(direction.normalized / 10);
            yield return new WaitForSeconds(0.01f);
        }
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), 0);
        position = transform.position;
        //CheckSameType.positionGameObjectPair[position] = gameObject;
        //Debug.Log(CheckSameType.positionGameObjectPair[position]);
    }

    //void Fall()
    //{
    //    if(transform.position.y > 0.1f)
    //    {
    //        if(!CheckSameType.positionGameObjectPair[position + Vector2.down])
    //        {
    //            Debug.Log("Fall");
    //            StartCoroutine(AnimateTranslate(transform, Vector2.down));
    //        }
    //    }
    //}
}
