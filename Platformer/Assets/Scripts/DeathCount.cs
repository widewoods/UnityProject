using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCount : MonoBehaviour
{
    public static int deathCount = 0;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Deaths:0";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Deaths:" + deathCount.ToString();
    }
}
