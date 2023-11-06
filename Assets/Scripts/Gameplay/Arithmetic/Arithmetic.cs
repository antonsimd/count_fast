using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arithmetic
{
    const int negativePercentage = 25;

    public static System.Random random = new System.Random();
    public static bool includeNegatives = false;

    public static void setNegatives(bool x) {
        includeNegatives = x;
    }

    public static bool negativesIncluded() {
        return includeNegatives;
    }

    public static int getRandomNumber() {
        var bottom = Difficulty.range.Item1;
        var top = Difficulty.range.Item2;

        int result = random.Next(bottom, top);
        int negative = random.Next(1, 101);

        if (includeNegatives && negative < negativePercentage) {
            result *= -1;
        }

        return result;
    }
}
