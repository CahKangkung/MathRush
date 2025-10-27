using System.Collections;
using System.Collections.Generic;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public AudioSource pauseAudio;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            pauseAudio.Play();

            if (GameIsPause) // nilainya true
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void LoadRestart()
    {
        Time.timeScale = 1f;
        GameIsPause = false;

        // PlayMakerFSM restartGame = GameObject.Find("Player").GetComponents<PlayMakerFSM>()
        //     .FirstOrDefault(fsm => fsm.FsmName == "PlayerLife");

        // restartGame.SendEvent("Reset");

        SceneManager.LoadScene("GameMode");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        GameIsPause = false;
        SceneManager.LoadScene("MainMenu");
    }
}
