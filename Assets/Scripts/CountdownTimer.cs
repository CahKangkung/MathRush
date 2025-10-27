using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public Image frameTimer;
    public float countdownDuration = 25f; // Durasi countdown
    private float currentTime;
    private bool isCounting = false;

    public void StartCountdown(float duration)
    {
        countdownDuration = duration;
        currentTime = duration;
        isCounting = true;
        countdownText.gameObject.SetActive(true);
        frameTimer.gameObject.SetActive(true);
    }

    public void StopCountdown()
    {
        isCounting = false;
        countdownText.gameObject.SetActive(false);
        frameTimer.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isCounting) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            isCounting = false;
            countdownText.gameObject.SetActive(false);
            frameTimer.gameObject.SetActive(false);
        }

        countdownText.text = Mathf.CeilToInt(currentTime).ToString();
    }
}
