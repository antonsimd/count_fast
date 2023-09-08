using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;
    public TextMeshProUGUI correctAnswer;
    void Awake() {
        instance = this;
    }

    void Start() {
        gameObject.SetActive(false);
    }

    public void gameOver(int answer) {
        gameObject.SetActive(true);
        correctAnswer.text = "= " + answer.ToString();
    }

    public void mainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void restartGame() {
        SceneManager.LoadScene("Game");
    }
}