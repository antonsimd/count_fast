using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    const string SCORE_TEXT_DEFAULT = "Score: ";

    int currentScore = 0;

    public static Score instance;

    void Awake() {
        instance = this;
    }

    void Start() {
        currentScore = 0;
        updateScore();
    }

    void updateScore() {
        scoreText.text = SCORE_TEXT_DEFAULT + currentScore.ToString();
    }

    public void addPoint() {
        currentScore++;
        updateScore();
    }

    public int getScore() {
        return currentScore;
    }
}
