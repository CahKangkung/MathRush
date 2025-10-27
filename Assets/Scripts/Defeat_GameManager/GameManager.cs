using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public float restartDelay = 2f;

    // void Start()
    // {
    //     Time.timeScale = 1f;
    // }
    public void Start()
    {
        ObstacleSettings.isSpawnObstacle = true;
    }

    public void EndGame()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);

        }
    }

    void Restart ()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("RestartMenu");
    }
    
}
