using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MainGame : MonoBehaviour
{

    public TextMeshProUGUI questionText;
    public static MainGame mainGame;

    // Min and max range for the numbers
    public (int, int) range = (1, 100);

    int answer;

    // Variable to store the execute function
    static Func<int> questionCreateFunction;

    public static void updateQuestionCreateFunction(Func<int> action) {
        questionCreateFunction = action;
    }

    void Awake() {
        mainGame = this;
    }

    void Start() {
        generateNewQuestion();
    }

    public void checkAnswer(long submission) {
        if (submission == answer) {
            generateNewQuestion();
        } else {
            GameOver.instance.gameOver(answer);
        }
    }

    // Only works with addition
    // TODO: fix after adding other operations
    void generateNewQuestion() {
        answer = questionCreateFunction();
    }
}
