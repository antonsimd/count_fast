using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtraction : MonoBehaviour
{
    static System.Random random = new System.Random();
    static bool includeNegatives = false;

    public static int generateQuestion() {
        int number1 = random.Next(Difficulty.range.Item1, Difficulty.range.Item2);
        int number2 = random.Next(Difficulty.range.Item1, Difficulty.range.Item2);

        if (!includeNegatives && number1 < number2) {
            MainGame.mainGame.questionText.text = number2.ToString() + " - " + number1.ToString();
            return number2 - number1;
        } else {
            MainGame.mainGame.questionText.text = number1.ToString() + " - " + number2.ToString();

            return number1 - number2;
        }
    }

    public static void setNegatives(bool x) {
        includeNegatives = x;
    }
}
