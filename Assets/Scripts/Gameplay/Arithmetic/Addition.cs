using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Addition : MonoBehaviour
{
    static System.Random random = new System.Random();

    public static int generateQuestion() {
        int number1 = random.Next(Difficulty.range.Item1, Difficulty.range.Item2);
        int number2 = random.Next(Difficulty.range.Item1, Difficulty.range.Item2);

        MainGame.mainGame.questionText.text = number1.ToString() + "+ " + number2.ToString();

        return number1 + number2;
    }
}
