using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] string scorePrefix = "Birds Eaten: ";

    private void Start() {
        Player.i.onBirdEat.AddListener(UpdateScoreText);
    }

    void UpdateScoreText() {
        scoreText.text = scorePrefix + Player.i.birdsEaten;
    }
}
