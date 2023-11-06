using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;
    public TextMeshProUGUI correctAnswer;
    [SerializeField] Animator transition;
    void Awake() {
        instance = this;
    }

    void Start() {
        gameObject.SetActive(false);
    }

    public void gameOver(int answer) {
        gameObject.SetActive(true);
        correctAnswer.text = "= " + answer.ToString();

        // Stop slider timer
        TimerSlider.instance.stopTimer();

        // Remove exit game popup if it is on screen
        ConfirmPopup.destroyPopupIfNeeded();
    }

    public void mainMenu() {
        loadScene("MainMenu");
    }

    public void restartGame() {
        loadScene("Game");
    }

    void loadScene(string sceneName) {
        StartCoroutine(SceneLoaderCoroutine.loadTransition(sceneName, transition));
    }
}
