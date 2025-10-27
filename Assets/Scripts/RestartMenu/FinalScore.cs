using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    // public Transform player;
    public Text scoreResult;
    public Text highScoreResult;

    public void Start()
    {
        int newScore = (int) StaticData.finalScore;

        //Tampilkan Final Score
        scoreResult.text = newScore.ToString();

        //Set High Score baru
        HighScoreData.TrySetNewHighScore(newScore);

        //Tampilkan High Score Terbaru
        int highest = HighScoreData.GetHighScore();
        highScoreResult.text = highest.ToString();

    }

}