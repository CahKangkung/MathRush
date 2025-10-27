using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ResetScoreScript : MonoBehaviour
{
    private const string Key = "HighScore";

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey(Key);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainMenu");
    
    }
}
