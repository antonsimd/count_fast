using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardInput : MonoBehaviour
{
    const int maxLongLength = 18;

    public TextMeshProUGUI answerText;
    public GameObject errorText;

    string answer = "";
    string text = "= ";

    void Start() {
        clearText();
    }

    public void writeNumber(int number = -1) {
        if (number != -1) {
            if (answer == "") {
                answer = number.ToString();
            } else if (answer.Length >= maxLongLength) {
                errorText.SetActive(true);
            } else {
                answer += number.ToString();
            }
        } else {
            answer = "";
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
        long answerInt = long.Parse(answer);
        clearText();
        MainGame.mainGame.checkAnswer(answerInt);
    }

    void clearText() {
        answer = "";
        updateText();
        errorText.SetActive(false);
    }
    void updateText() {
        answerText.text = text + answer;
    }
}
