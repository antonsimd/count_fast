using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arithmetic
{
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

        if (includeNegatives) {
            bottom *= -1;
        }
        return random.Next(bottom, top);
    }
}
