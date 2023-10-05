using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MainGame : MonoBehaviour
{
    // Enum to store all game modes
    public enum GameModes {
        PRACTICE,
        GAME
    };

    public TextMeshProUGUI questionText;
    public static MainGame mainGame;
    int answer;

    // Variable to store the execute function
    // Random by default
    static Func<int> questionCreateFunction = RandomGame.generateQuestion;

    // Variable to store the current game mode
    // Practice by default
    public static GameModes gameMode = GameModes.PRACTICE;

    bool gameOver = false;

    public static void updateQuestionCreateFunction(Func<int> action) {
        questionCreateFunction = action;
    }

    public static void changeGameMode(GameModes update) {
        gameMode = update;
    }

    void Awake() {
        mainGame = this;
    }

    void Start() {
        gameOver = false;
        generateNewQuestion();
        if (gameMode == GameModes.GAME) {
            TimerSlider.instance.initialiseTimer();
            Score.instance.initialiseScore();
        }
    }

    void Update() {
        // Check for gameOver
        if (gameMode == GameModes.GAME) {

            // GameOver is set to either true or false
            gameOver |= TimerSlider.instance.gameStatus();
            if (gameOver) {
                GameOver.instance.gameOver(answer);
            }
        }
    }

    public void checkAnswer(long submission) {
        if (submission == answer) {
            AnswerText.instance.correctAnswer();
            generateNewQuestion();

            // Reset timer if the game mode is a game
            if (gameMode == GameModes.GAME) {
                TimerSlider.instance.resetTimer();
                Score.instance.addPoint();
            }

        } else if (gameMode == GameModes.PRACTICE) {
            AnswerText.instance.wrongAnswer();
        } else {
            gameOver = true;
        }

        // Clear the answer field
        KeyboardInput.instance.clearText();
    }

    void generateNewQuestion() {
        answer = questionCreateFunction();
    }
}
