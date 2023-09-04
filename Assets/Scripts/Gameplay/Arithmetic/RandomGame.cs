using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomGame : MonoBehaviour
{
    const int questionsLength = 4;

    // List of all functions which can be used to generate questions
    static Func<int>[] questions = {
        Addition.generateQuestion,
        Subtraction.generateQuestion,
        Multiplication.generateQuestion,
        Division.generateQuestion
    };

    static System.Random random = new System.Random();

    public static int generateQuestion() {
        int index = random.Next(0, questionsLength);

        // Call a function at a random index
        return questions[index]();
    }
}
