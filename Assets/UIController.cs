using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText, timerText;
    [SerializeField] string scorePrefix = "Birds Eaten: ";
    [SerializeField] string timerPrefix = "Time: ";

    float totalTime = 0;

    private void Update()
    {
        UpdateTimerText();
        totalTime += Time.deltaTime;
    }
    private void Start()
    {
        Player.i.onBirdEat.AddListener(UpdateScoreText);
    }

    void UpdateScoreText()
    {
        scoreText.text = scorePrefix + Player.i.birdsEaten;
    }

    void UpdateTimerText()
    {
        timerText.text = timerPrefix + Mathf.Round(totalTime);
    }
}
