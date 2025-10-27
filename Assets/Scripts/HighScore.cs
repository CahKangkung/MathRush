using System.Collections;
using System.Collections.Generic;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    // Start is called before the first frame update
    public Text highestScore;
    void Start()
    {
        // int newScore = (int)StaticData.finalScore;
        // highestScore.text = newScore.ToString();

        // highestScore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();

        int highest = HighScoreData.GetHighScore();
        highestScore.text = highest.ToString();
    }

}
