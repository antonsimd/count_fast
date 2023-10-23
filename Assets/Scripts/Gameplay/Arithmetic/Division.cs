using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Division : Arithmetic
{
    const int multiplicationRangeFactor = 5;

    static int getRandomNumber() {
        int bottom = Difficulty.MDRange.Item1;
        int top = Difficulty.MDRange.Item2;

        if (includeNegatives) {
            bottom *= -1;
        }
        return random.Next(bottom, top);
    }

    public static int generateQuestion() {
        int number1 = getRandomNumber();
        int number2 = getRandomNumber();

        while (number2 == 0) {
            number2 = getRandomNumber();
        }

        // Do the reverse of multiplication
        MainGame.mainGame.questionText.text = (number1 * number2).ToString() + " ÷ " + number2.ToString();

        return number1;
    }
}
