using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void MainScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("ResetMenu");
    }

    public void ModePermainan()
    {
        SceneManager.LoadScene("GameMode");
    }

    public void ModeLanjutPermainan()
    {
        SceneManager.LoadScene("Game2Mode");
    }

    public void ModeDatar()
    {
        SceneManager.LoadScene("GameMode");
    }

    public void ModeRuang()
    {
        SceneManager.LoadScene("Game2Mode");
    }

    public void StartGame()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("GameScene");
    }

    public void StartGameRuang()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Game2Scene");
    }

    public void RestartGame()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene("GameScene");
        // SceneManager.LoadScene("SampleScene");
    }

    public void HelpGame()
    {
        // Masuk Scene Pilih Lihat Materi / Control
        SceneManager.LoadScene("HelpMenu");
    }

    public void PilihMateri()
    {
        SceneManager.LoadScene("OpsiMateri");
    }

    public void PilihPanduan()
    {
        SceneManager.LoadScene("OpsiPanduan");
    }

    public void CreditsGame()
    {
        // Masuk Scene Credits
        SceneManager.LoadScene("CreditsMenu");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        // Application.Quit();
        SceneManager.LoadScene("MainMenu");
    }

    public void BackGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ExitGame()
    {
        Debug.Log("SHUTDOWN GAME");
        Application.Quit();
    }

    // void start()
    // {
    //     finalScore.text = PlayerPrefs.GetFloat("FinalScore", 0).ToString();
    // }
}
