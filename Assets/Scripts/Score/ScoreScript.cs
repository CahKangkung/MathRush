using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    // public Transform player;
    public Text scoreText;
    private float score = 0f;
    public float scoreSpeed = 10f;

    private float nextSpeedUpTime = 10f; // Waktu pertama kali naik difficulty
    public float speedUpInterval = 10f; // Setiap 10 detik difficult naik

    public float correctScore = 50f;
    public float wrongScore = 50f;

    // Update is called once per frame
    void FixedUpdate()
    {
        score += scoreSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString();

        if (Time.time > nextSpeedUpTime)
        {
            scoreSpeed += 1f;
            nextSpeedUpTime = Time.time + speedUpInterval;
        }

        StaticData.finalScore = score;

        // if (score > PlayerPrefs.GetFloat("HighScore", 0))
        // {
        //     PlayerPrefs.SetFloat("FinalScore", score);
        //     scoreText.text = score.ToString();
        // }

        // PlayerPrefs.SetFloat("FinalScore", score);

        // scoreText.text = player.position.z.ToString("0");
    }
    public void PlusPoin(float amount)
    {
        score += amount;
        if (score < 0f)
        {
            score = 0f;
        }
        scoreText.text = Mathf.FloorToInt(score).ToString();

    }
    public void MinusPoin(float amount)
    {
        PlusPoin(-amount);
    }
}
