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
    static GameModes gameMode = GameModes.PRACTICE;

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
        generateNewQuestion();
    }

    public void checkAnswer(long submission) {
        if (submission == answer) {
            AnswerText.instance.correctAnswer();
            KeyboardInput.instance.clearText();
            generateNewQuestion();
        } else if (gameMode == GameModes.PRACTICE) {
            AnswerText.instance.wrongAnswer();
        } else {
            GameOver.instance.gameOver(answer);
        }
    }

    void generateNewQuestion() {
        answer = questionCreateFunction();
    }
}
