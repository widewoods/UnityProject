using UnityEngine.SceneManagement;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float resetDelay = 1f;

    public GameObject completeGameUI;

    public void CompleteLevel()
    {
        completeGameUI.SetActive(true);
    }

    public void EndGame ()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", resetDelay);
        }
        
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
     
}
