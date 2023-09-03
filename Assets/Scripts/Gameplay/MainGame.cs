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

    void Awake() {
        mainGame = this;
    }

    void Start() {
        generateNewQuestion();
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
