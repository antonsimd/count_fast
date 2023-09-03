using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainGame : MonoBehaviour
{

    public TextMeshProUGUI questionText;
    public static MainGame mainGame;

    // Min and max range for the numbers
    public (int, int) range = (1, 100);

    int answer;
    bool newQuestionRequired = false;

    void Awake() {
        mainGame = this;
    }

    void Start() {
        generateNewQuestion();
    }

    void Update() {
        if (newQuestionRequired) {
            generateNewQuestion();
        }
    }

    public void checkAnswer(long submission) {
        if (submission == answer) {
            generateNewQuestion();
        }
    }

    // Only works with addition
    // TODO: fix after adding other operations
    void generateNewQuestion() {
        answer = Addition.generateAdditionQuestion();
    }
}
