using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public Text scoreText;
    public int score;

    void Start()
    {
        //Reset score to 0
        score = 0;
        scoreText.text = score.ToString();
    }
     
    public void Score()
    {
        //Add score. Function is called from Ballmovement.cs when reaching goal.
        score += 1;
        scoreText.text = score.ToString();
    }
}
