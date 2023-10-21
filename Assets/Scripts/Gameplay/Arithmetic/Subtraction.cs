using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtraction : Arithmetic
{
    public static int generateQuestion() {
        int number1 = getRandomNumber();
        int number2 = getRandomNumber();

        if (!includeNegatives && number1 < number2) {
            MainGame.mainGame.questionText.text = number2.ToString() + " - " + number1.ToString();
            return number2 - number1;
        } else {
            MainGame.mainGame.questionText.text = number1.ToString() + " - " + number2.ToString();

            return number1 - number2;
        }
    }
}
