using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty
{
    const int DEFAULT_DIFFICULTY = 4;
    static int current_difficulty = DEFAULT_DIFFICULTY;

    // PlayerPrefs key for difficulty
    const string difficultyKey = "difficulty";

    // Range of random numbers
    public static (int, int) range = (1, 100);
    public static (int, int) MDRange = (1, 20);

    public static int initialiseDifficulty() {
        if (!PlayerPrefs.HasKey(difficultyKey)) {
            PlayerPrefs.SetInt(difficultyKey, DEFAULT_DIFFICULTY);
            PlayerPrefs.Save();
            current_difficulty = DEFAULT_DIFFICULTY;
        } else {
            current_difficulty = PlayerPrefs.GetInt(difficultyKey);
        }

        return current_difficulty;
    }

    public static int getDifficulty() {
        return current_difficulty;
    }

    public static void setDifficulty(int newDifficulty) {
        current_difficulty = newDifficulty;

        // Update PlayerPrefs to save across app closes
        PlayerPrefs.SetInt(difficultyKey, current_difficulty);
        PlayerPrefs.Save();
    }

    public static void setMinRange(int number) {
        range.Item1 = number;
    }

    public static void setMaxRange(int number) {
        // Add 1 because C# excludes the number at the top of the range
        range.Item2 = number + 1;
    }

    public static void setMinMDRange(int number) {
        MDRange.Item1 = number;
    }

    public static void setMaxMDRange(int number) {
        // Add 1 because C# excludes the number at the top of the range
        MDRange.Item2 = number + 1;
    }
}
