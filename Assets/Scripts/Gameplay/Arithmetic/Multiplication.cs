using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplication : Arithmetic
{
    const int multiplicationRangeFactor = 5;

    public static int generateQuestion() {
        int number1 = getRandomNumber();
        int number2 = getRandomNumber();

        MainGame.mainGame.questionText.text = number1.ToString() + " × " + number2.ToString();

        return number1 * number2;
    }
}
