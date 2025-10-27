using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LearningSequence : MonoBehaviour
{
    public GameObject learnWarnPanel;
    public GameObject[] learnPanel;
    public GameObject exampleWarnPanel;
    public GameObject[] examplePanel;
    public GameObject quizCanvas;
    // public GameObject quizWarnPanel;

    // public QuizManager quizManager;
    public float playTime = 10f;
    public float learnWarnTime = 5f;
    public float learnTime = 25f;
    public float between1 = 10f;                 // setelah materi, main lagi 40s sebelum contoh
    public float exampleWarnTime = 5f;
    public float exampleTime = 25f;
    public float between2 = 10f;                 // setelah contoh, main lagi 10s sebelum quiz
    public float quizWarnTime = 5f;
    public float quizTime = 30f;
    public float postQuizHold = 5f;

    public GameObject timerSystem;
    public GameObject quizSystem;

    [HideInInspector]
    public bool paused = false;
    IEnumerator WaitUnpaused(float seconds)
    {
        float elapsed = 0f;
        while (elapsed < seconds)
        {
            if (!paused)
                elapsed += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator Start()
    {
        learnWarnPanel.SetActive(false);
        exampleWarnPanel.SetActive(false);
        //quizWarnPanel.SetActive(false);
        foreach (var mtr in learnPanel) mtr.SetActive(false);
        foreach (var obj in examplePanel) obj.SetActive(false);

        for (int cycle = 0; cycle < learnPanel.Length; cycle++)
        {
            // yield return new WaitForSeconds(playTime);
            yield return StartCoroutine(WaitUnpaused(playTime));

            learnWarnPanel.SetActive(true);
            // yield return new WaitForSeconds(learnWarnTime);
            yield return StartCoroutine(WaitUnpaused(learnWarnTime));
            learnWarnPanel.SetActive(false);

            learnPanel[cycle].SetActive(true);
            //ObstacleSettings.isSpawnObstacle = false;
            timerSystem.GetComponent<CountdownTimer>().StartCountdown(25f);
            ObstacleSettings.isSpawnObstacle = false;
            GameObject[] allObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            foreach (var obstacle in allObstacles)
            {
                Destroy(obstacle);
            }

            // yield return new WaitForSeconds(learnTime);
            yield return StartCoroutine(WaitUnpaused(learnTime));
            timerSystem.GetComponent<CountdownTimer>().StopCountdown();
            learnPanel[cycle].SetActive(false);
            ObstacleSettings.isSpawnObstacle = true;

            // yield return new WaitForSeconds(between1);
            yield return StartCoroutine(WaitUnpaused(between1));

            exampleWarnPanel.SetActive(true);
            // yield return new WaitForSeconds(exampleWarnTime);
            yield return StartCoroutine(WaitUnpaused(exampleWarnTime));
            exampleWarnPanel.SetActive(false);

            examplePanel[cycle].SetActive(true);
            timerSystem.GetComponent<CountdownTimer>().StartCountdown(25f);
            ObstacleSettings.isSpawnObstacle = false;
            GameObject[] leftObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            foreach (var obstacle in leftObstacles)
            {
                Destroy(obstacle);
            }

            // yield return new WaitForSeconds(exampleTime);
            yield return StartCoroutine(WaitUnpaused(exampleTime));
            timerSystem.GetComponent<CountdownTimer>().StopCountdown();
            examplePanel[cycle].SetActive(false);
            ObstacleSettings.isSpawnObstacle = true;

            // yield return new WaitForSeconds(between2);
            yield return StartCoroutine(WaitUnpaused(between2));

            // quizManager.currentCycle = cycle;
            // yield return new WaitForSeconds(quizWarnTime);
            yield return StartCoroutine(WaitUnpaused(quizWarnTime));
            quizSystem.GetComponent<QuizManager>().ShowRandomQuestionBasedCycle(cycle);
            // quizManager.ShowRandomQuestionBasedCycle(cycle);
            quizCanvas.SetActive(true);
            timerSystem.GetComponent<CountdownTimer>().StartCountdown(30f);
            // yield return new WaitForSeconds(quizTime);
            yield return StartCoroutine(WaitUnpaused(quizTime));
            quizCanvas.SetActive(false);
            timerSystem.GetComponent<CountdownTimer>().StopCountdown();
            // yield return new WaitForSeconds(postQuizHold);
            yield return StartCoroutine(WaitUnpaused(postQuizHold));

        }
        //Setelah selesai 8 cycle atau bangun datar/ruang
        SceneManager.LoadScene("WinnerMenu");
    }

}
