using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSameType : MonoBehaviour
{
    public static List<List<GameObject>> columns = new List<List<GameObject>>();

    public int horizontalMatchCount = 1;
    public int verticalMatchCount = 1;

    public GameManager gameManager;

    public int row;
    public int column;

    private void Start()
    {
        StartCoroutine(MatchAll());
    }

    private void Update()
    {

    }

    public IEnumerator Match(int row, int column, string direction)
    {
        if(direction == "Horizontal")
        {
            for (int x = 0; x < 8; x++)
            {
                if (columns[x][row].GetComponent<Jewel>().type == columns[x + 1][row].GetComponent<Jewel>().type)
                {
                    horizontalMatchCount++;
                    if (horizontalMatchCount == 3)
                    {
                        StopCoroutine(MatchAll());
                        for (int i = 1; i > -2; i--)
                        {
                            GameManager.RemoveAtPos(columns[x + i][row].transform.position, gameManager.tempPrefab);
                            yield return new WaitForEndOfFrame();
                        }
                        horizontalMatchCount = 1;
                        StartCoroutine(MatchAll());
                    }
                }
                else
                {
                    horizontalMatchCount = 1;
                }
                
            }
        }

        if (direction == "Vertical")
        {
            for (int x = 0; x < 8; x++)
            {
                if (columns[column][x].GetComponent<Jewel>().type == columns[column][x + 1].GetComponent<Jewel>().type)
                {
                    verticalMatchCount++;
                    if (verticalMatchCount == 3)
                    {
                        StopCoroutine(MatchAll());
                        for (int i = 1; i > -2; i--)
                        {
                            GameManager.RemoveAtPos(columns[column][x + i].transform.position, gameManager.tempPrefab);
                            yield return new WaitForEndOfFrame();
                        }
                        verticalMatchCount = 1;
                        StartCoroutine(MatchAll());
                    }
                }
                else
                {
                    verticalMatchCount = 1;
                }

            }
        }
    }

    public IEnumerator MatchAll()
    {
        //while (true)
        //{
        //    yield return new WaitForSeconds(0.2f);
        //    for (int row = 0; row < 9; row++)
        //    {
        //        StartCoroutine(Match(row, column, "Horizontal"));
        //        yield return null;
        //    }

        //    for (int column = 0; column < 9; column++)
        //    {
        //        StartCoroutine(Match(row, column, "Vertical"));
        //        yield return null;
        //    }
        //}
        yield return new WaitForSeconds(0.2f);
        for (int row = 0; row < 9; row++)
        {
            StartCoroutine(Match(row, column, "Horizontal"));
            yield return new WaitForEndOfFrame();
        }

        for (int column = 0; column < 9; column++)
        {
            StartCoroutine(Match(row, column, "Vertical"));
            yield return new WaitForEndOfFrame();

        }
    }
}
