using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplication : MonoBehaviour
{
    const int multiplicationRangeFactor = 5;

    static System.Random random = new System.Random();

    public static int generateQuestion() {
        int number1 = random.Next(Difficulty.range.Item1, Difficulty.range.Item2 / multiplicationRangeFactor);
        int number2 = random.Next(Difficulty.range.Item1, Difficulty.range.Item2 / multiplicationRangeFactor);

        MainGame.mainGame.questionText.text = number1.ToString() + "× " + number2.ToString();

        return number1 * number2;
    }
}
