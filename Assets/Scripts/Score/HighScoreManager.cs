using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class HighScoreManager : MonoBehaviour
// {
public static class HighScoreData
{
    private const string Key = "HighScore";

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(Key, 0);
    }

    public static void TrySetNewHighScore(int newScore)
    {
        int currentHigh = GetHighScore();
        if (newScore > currentHigh)
        {
            PlayerPrefs.SetInt(Key, newScore);
            PlayerPrefs.Save();
        }
    }
}
// }
