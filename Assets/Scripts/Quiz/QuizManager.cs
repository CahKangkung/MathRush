using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// public class NewBehaviourScript : MonoBehaviour
public struct Option
{
    public string text;
    public bool isCorrect;
    public Option(string t, bool correct)
    {
        text = t;
        isCorrect = correct;
    }
}

public class QuizManager : MonoBehaviour
{
    public GameObject quizPanel;
    public Text questionText;
    public Button[] answerButtons;
    public List<QuestionData> questions;

    private int currentAnswerIndex;
    private ScoreScript takeScore;

    // Start is called before the first frame update
    void Start()
    {
        quizPanel.SetActive(false);
        takeScore = FindObjectOfType<ScoreScript>();
        if (takeScore == null)
        {
            Debug.LogError("Tidak ada ScoreScript");
        }
    }


    public void ShowRandomQuestion()
    {
        quizPanel.SetActive(true);

        // Ambil soal acak
        QuestionData q = questions[Random.Range(0, questions.Count)];
        questionText.text = q.questionText;
        // currentAnswerIndex = q.answerIndex;

        // Acak Posisi Jawaban
        // List<int> indexOrder = new List<int> { 0, 1, 2 };
        // Shuffle(indexOrder); ini dari dulu komen

        // Bangun list Option (teks + apakah jawaban benar)
        var options = new List<Option>();
        for (int i = 0; i < q.answers.Length; i++)
        {
            bool correct = (i == q.answerIndex);
            options.Add(new Option(q.answers[i], correct));
        }

        // Acak urutan opsi/jawaban
        for (int i = options.Count - 1; i > 0; i--)
        {
            int r = Random.Range(0, i + 1);
            var tmp = options[i];
            options[i] = options[r];
            options[r] = tmp;
        }

        // Assign teks dan listener baru ke masing‑masing button
        for (int i = 0; i < answerButtons.Length; i++)
        {
            var btn = answerButtons[i];
            var opt = options[i];

            btn.GetComponentInChildren<Text>().text = opt.text;
            btn.onClick.RemoveAllListeners();
            // kirim langsung apakah benar atau tidak
            btn.onClick.AddListener(() => CheckAnswer(opt.isCorrect, btn));
        }

        // for (int i = 0; i < 3; i++)
        // {
        //     int idx = indexOrder[i];
        //     answerButtons[i].GetComponentInChildren<Text>().text = q.answers[idx];
        //     int buttonIndex = i; // Local copy untuk lambda
        //     answerButtons[i].onClick.RemoveAllListeners();
        //     answerButtons[i].onClick.AddListener(() => CheckAnswer(idx, q.answerIndex, buttonIndex));

        //     Debug.Log(answerButtons[i].name);
        //     Debug.Log(answerButtons[i].GetComponentInChildren<Text>());
        // }

        ObstacleSettings.isSpawnObstacle = false;
        GameObject[] allObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (var obstacle in allObstacles)
        {
            Destroy(obstacle);
        }

    }

    public int currentCycle = 0;

    public void ShowRandomQuestionBasedCycle(int cycleIndex)
    {
        currentCycle = cycleIndex;
        var filter = questions.FindAll(q => q.shapeIndex == cycleIndex);
        if (filter.Count > 0)
            questions = filter;
            
        ShowRandomQuestion();
    }

    private bool alreadyAnswered = false;
    // void CheckAnswer(int buttonIndex, int clickIndex, int correctIndex)
    void CheckAnswer(bool isCorrect, Button button)
    {
        if (alreadyAnswered) return;
        alreadyAnswered = true;

         // Warnai hijau/merah
        var img = button.GetComponent<Image>();
        img.color = isCorrect ? Color.green : Color.red;

        PlayMakerFSM quizFailFSM = GameObject.Find("Player").GetComponents<PlayMakerFSM>()
            .FirstOrDefault(fsm => fsm.FsmName == "LifeDecrement");

        PlayMakerFSM wrongAnswer = GameObject.Find("Player").GetComponents<PlayMakerFSM>()
            .FirstOrDefault(fsm => fsm.FsmName == "AudioWrong");

        PlayMakerFSM correctAnswer = GameObject.Find("Player").GetComponents<PlayMakerFSM>()
            .FirstOrDefault(fsm => fsm.FsmName == "AudioCorrect");

        // if (clickIndex == correctIndex)
        if (isCorrect)
        {
            // answerButtons[buttonIndex].GetComponent<Image>().color = Color.green;
            Debug.Log("Jawaban Benar");

            takeScore.PlusPoin(takeScore.correctScore);

            // PlayMakerFSM playerLifeFSM = GameObject.Find("Player").GetComponent<PlayMakerFSM>(); // Pastikan FSM ada di GO "Player"
            // playerLifeFSM.SendEvent("CORRECT_ANSWER");

            quizFailFSM.SendEvent("CORRECT_ANSWER");
            correctAnswer.SendEvent("CORRECT_ANSWER");

            // naikkan kesulitan
            // FindObjectOfType<DifficultyManager>()?.OnCorrectAnswer();
        }
        else
        {
            // answerButtons[buttonIndex].GetComponent<Image>().color = Color.red;
            Debug.Log("Jawaban Salah");

            takeScore.MinusPoin(takeScore.wrongScore);

            // PlayMakerFSM playerLifeFSM = GameObject.Find("Player").GetComponent<PlayMakerFSM>(); // Pastikan FSM ada di GO "Player"
            // playerLifeFSM.SendEvent("WRONG_ANSWER");

            quizFailFSM.SendEvent("WRONG_ANSWER");
            wrongAnswer.SendEvent("WRONG_ANSWER");

        }

        // var fsm = FindObjectOfType<PlayMakerFSM>();
        // fsm.FsmVariables.GetFsmBool("HasAnswered").Value = true;

        PlayMakerFSM quizSettingsFSM = GameObject.Find("Player").GetComponents<PlayMakerFSM>()
            .FirstOrDefault(fsm => fsm.FsmName == "QuizSettings");

        quizSettingsFSM.FsmVariables.GetFsmBool("HasAnswered").Value = true;

        PlayMakerFSM.BroadcastEvent("ANSWERED");

        // Tutup soal setelah 2 detik
        Invoke("CloseQuestion", 2f);
    }

    void CloseQuestion()
    {
        foreach (Button btn in answerButtons)
        {
            btn.GetComponent<Image>().color = Color.white;
        }
        quizPanel.SetActive(false);

        ObstacleSettings.isSpawnObstacle = true;

        alreadyAnswered = false;

        var seq = FindObjectOfType<LearningSequence>();
        if (seq != null) seq.paused = false;
    }

    void Shuffle(List<int> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int rand = Random.Range(0, i + 1);
            int temp = list[i];
            list[i] = list[rand];
            list[rand] = temp;

        }
    }

}
