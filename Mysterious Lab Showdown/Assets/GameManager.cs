using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(EnemyScript.enemyCount == 0 && Input.GetKeyDown(KeyCode.C))
        {
            EndLevel();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void EndLevel()
    {
        //Animation showing level cleared
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
