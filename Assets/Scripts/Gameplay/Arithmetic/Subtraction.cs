using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtraction : MonoBehaviour
{
    static System.Random random = new System.Random();

    public static int generateQuestion() {
        int number1 = random.Next(MainGame.mainGame.range.Item1, MainGame.mainGame.range.Item2);
        int number2 = random.Next(MainGame.mainGame.range.Item1, MainGame.mainGame.range.Item2);

        MainGame.mainGame.questionText.text = number1.ToString() + "- " + number2.ToString();

        return number1 - number2;
    }
}