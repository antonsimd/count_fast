using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Division : MonoBehaviour
{
    const int multiplicationRangeFactor = 5;

    static System.Random random = new System.Random();

    public static int generateQuestion() {
        int number1 = random.Next(MainGame.mainGame.range.Item1, MainGame.mainGame.range.Item2 / multiplicationRangeFactor);
        int number2 = random.Next(MainGame.mainGame.range.Item1, MainGame.mainGame.range.Item2 / multiplicationRangeFactor);

        // Do the reverse of multiplication
        MainGame.mainGame.questionText.text = (number1 * number2).ToString() + "÷ " + number2.ToString();

        return number1;
    }
}
