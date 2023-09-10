using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplication : MonoBehaviour
{
    const int multiplicationRangeFactor = 5;

    static System.Random random = new System.Random();

    public static int generateQuestion() {
        int number1 = random.Next(Difficulty.MDRange.Item1, Difficulty.MDRange.Item2);
        int number2 = random.Next(Difficulty.MDRange.Item1, Difficulty.MDRange.Item2);

        MainGame.mainGame.questionText.text = number1.ToString() + "× " + number2.ToString();

        return number1 * number2;
    }
}
