using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class DifficultyInput : MonoBehaviour
{
    public enum GameTypes {
        Addition,
        Subtraction,
        Multiplication,
        Division
    };

    public static GameTypes gameType = GameTypes.Addition;

    [SerializeField] GameObject minInput;
    [SerializeField] GameObject maxInput;

    const string MIN_AS_NUMBER = "minNumber";
    const string MAX_AS_NUMBER = "maxNumber";

    const string MIN_MD_NUMBER = "minMDNumber";
    const string MAX_MD_NUMBER = "maxMDNumber";

    static string minNumberKey = MIN_AS_NUMBER;
    static string maxNumberKey = MAX_AS_NUMBER;
    const int DEFAULT_MIN = 0;
    const int DEFAULT_MAX = 100;

    // Variables for storing min and max inputs
    TMP_InputField minInputText;
    TMP_InputField maxInputText;

    public static void setGameMode(GameTypes updatedGameType) {
        gameType = updatedGameType;

        if (updatedGameType == GameTypes.Addition || updatedGameType == GameTypes.Subtraction) {
            minNumberKey = MIN_AS_NUMBER;
            maxNumberKey = MAX_AS_NUMBER;
        } else if (updatedGameType == GameTypes.Multiplication || updatedGameType == GameTypes.Division) {
            minNumberKey = MIN_MD_NUMBER;
            maxNumberKey = MAX_MD_NUMBER;
        }
    }

    void Start() {
        minInputText = minInput.GetComponent<TMP_InputField>();
        maxInputText = maxInput.GetComponent<TMP_InputField>();

        initialiseDifficulty();
    }

    void initialiseDifficulty() {

        // Check for an exising number in PlayerPrefs
        // Set text to an existing number or to a default value if the key
        // Does not exist
        if (!PlayerPrefs.HasKey(minNumberKey)) {
            PlayerPrefs.SetInt(minNumberKey, DEFAULT_MIN);
            PlayerPrefs.Save();
            minInputText.text = DEFAULT_MIN.ToString();
        } else {
            minInputText.text = PlayerPrefs.GetInt(minNumberKey).ToString();
        }

        if (!PlayerPrefs.HasKey(maxNumberKey)) {
            PlayerPrefs.SetInt(maxNumberKey, DEFAULT_MAX);
            PlayerPrefs.Save();
            maxInputText.text = DEFAULT_MAX.ToString();
        } else {
            maxInputText.text = PlayerPrefs.GetInt(maxNumberKey).ToString();
        }
    }

    public void setMinDifficulty() {
        int parsedNumber = Int32.Parse(minInputText.text);
        if (gameType == GameTypes.Addition || gameType == GameTypes.Subtraction) {
            Difficulty.setMinRange(parsedNumber);
        } else {
            Difficulty.setMinMDRange(parsedNumber);
        }

        // Update PlayerPrefs to save across app closes
        PlayerPrefs.SetInt(minNumberKey, parsedNumber);
        PlayerPrefs.Save();
    }

    public void setMaxDifficulty() {

        int parsedNumber = Int32.Parse(maxInputText.text);
        if (gameType == GameTypes.Addition || gameType == GameTypes.Subtraction) {
            Difficulty.setMaxRange(parsedNumber);
        } else {
            Difficulty.setMaxMDRange(parsedNumber);
        }

        // Update PlayerPrefs to save across app closes
        PlayerPrefs.SetInt(maxNumberKey, parsedNumber);
        PlayerPrefs.Save();
    }
}
