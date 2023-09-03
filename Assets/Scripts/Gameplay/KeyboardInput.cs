using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardInput : MonoBehaviour
{
    public TextMeshProUGUI answerText;
    string answer = "";
    string text = "= ";

    void Start() {
        clearText();
    }

    public void writeNumber(int number = -1) {
        if (number != -1) {
            if (answer == "") {
                answer = number.ToString();
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
    }

    void clearText() {
        answer = "";
        updateText();
    }
    void updateText() {
        answerText.text = text + answer;
    }
}
