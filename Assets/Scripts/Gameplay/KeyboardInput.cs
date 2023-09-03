using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardInput : MonoBehaviour
{
    public TextMeshProUGUI answerText;
    string answer = null;
    string text = "= ";

    void Start() {
        updateText();
    }

    public void updateText(int number = -1) {
        if (number != -1) {
            if (answer == null) {
                answer = number.ToString();
            } else {
                answer += number.ToString();
            }
        } else {
            answer = null;
        }

        answerText.text = answer == null ? text : text + answer;
    }
}
