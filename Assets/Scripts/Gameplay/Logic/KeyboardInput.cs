using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardInput : MonoBehaviour
{
    const int maxLongLength = 18;
    const string POSITIVE_NUMBER = "= ";
    const string NEGATIVE_NUMBER = "= - ";

    public TextMeshProUGUI answerText;
    public GameObject errorText;
    public GameObject enterNumberText;
    public static KeyboardInput instance;

    string answer = "";
    string text = POSITIVE_NUMBER;
    bool answerNegative = false;

    void Awake() {
        instance = this;
    }

    void Start() {
        clearText();
    }

    public void writeNumber(int number) {
        enterNumberText.SetActive(false);

        if (answer.Length >= maxLongLength) {
            errorText.SetActive(true);
        } else {
            answer += number.ToString();
        }

        updateText();
    }

    public void backspace() {
        if (answer.Length != 0) {
            answer = answer.Remove(answer.Length - 1, 1);
            updateText();
        }

        if (answer.Length < maxLongLength) {
            errorText.SetActive(false);
        }
    }

    public void submitAnswer() {
        if (answer == "") {
            enterNumberText.SetActive(true);
            return;
        }

        long answerInt = long.Parse(answer);

        answerInt *= answerNegative == true ? -1 : 1;
        MainGame.mainGame.checkAnswer(answerInt);
    }

    public void toggleSign() {
        if (answerNegative == false) {
            text = NEGATIVE_NUMBER;
        } else {
            text = POSITIVE_NUMBER;
        }

        answerNegative = !answerNegative;
        updateText();
    }

    public void clearText() {
        answer = "";
        answerNegative = false;
        text = POSITIVE_NUMBER;
        updateText();
        errorText.SetActive(false);
    }
    void updateText() {
        answerText.text = text + answer;
    }
}
