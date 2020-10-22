using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    int curLocation = 0;
    public Text[] countText = new Text[40];
    private int[] arriveCount = new int[40];
    public Image[] countImage = new Image[40];
    private int rollCount = 0;
    public Text rollCountText;
    int a = 0;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RollDice();
    }
    void RollDice()
    {
        System.Random rnd = new System.Random();
        int diceA = rnd.Next(1, 6);
        int diceB = rnd.Next(1, 6);
        int dieSum = diceA + diceB;
        curLocation = curLocation + dieSum;
        rollCount++;
        rollCountText.text = "RollCount = " + rollCount.ToString();
        if (curLocation > 40)
        {
            curLocation = curLocation - 41;
        }
        for (int i = 0; i < 40; i++)
        {
            if (curLocation == i)
            {
                //arriveCount[i] = +1;
                arriveCount[i] += 1;
                //countText[i].text = arriveCount[i].ToString();
                //print(i);
                countImage[i].fillAmount = arriveCount[i] / (float)20;
            }
            
        }
    }


}
//text.text = text + ArriveCount