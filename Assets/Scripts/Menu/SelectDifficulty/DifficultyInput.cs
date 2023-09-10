using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class DifficultyInput : MonoBehaviour
{
    [SerializeField] GameObject minInput;
    [SerializeField] GameObject maxInput;

    const string minNumberKey = "minNumber";
    const string maxNumberKey = "maxNumber";
    const int DEFAULT_MIN = 0;
    const int DEFAULT_MAX = 100;

    // Variables for storing min and max inputs
    string minInputText;
    string maxInputText;


    void Start() {
        minInputText = minInput.GetComponent<TMP_InputField>().text;
        maxInputText = maxInput.GetComponent<TMP_InputField>().text;

        initialiseDifficulty();
    }

    void initialiseDifficulty() {

        // Check for an exising number in PlayerPrefs
        // Set text to an existing number or to a default value if the key
        // Does not exist
        if (!PlayerPrefs.HasKey(minNumberKey)) {
            PlayerPrefs.SetInt(minNumberKey, DEFAULT_MIN);
            PlayerPrefs.Save();
            minInputText = DEFAULT_MIN.ToString();
        } else {
            minInputText = PlayerPrefs.GetInt(minNumberKey).ToString();
        }

        if (!PlayerPrefs.HasKey(maxNumberKey)) {
            PlayerPrefs.SetInt(maxNumberKey, DEFAULT_MAX);
            PlayerPrefs.Save();
            maxInputText = DEFAULT_MAX.ToString();
        } else {
            maxInputText = PlayerPrefs.GetInt(maxNumberKey).ToString();
        }
    }

    public void setMinDifficulty() {
        int parsedNumber = Int32.Parse(minInputText);
        Difficulty.setMinRange(parsedNumber);

        // Update PlayerPrefs to save across app closes
        PlayerPrefs.SetInt(minNumberKey, parsedNumber);
        PlayerPrefs.Save();
    }

    public void setMaxDifficulty() {
        int parsedNumber = Int32.Parse(maxInputText);
        Difficulty.setMaxRange(parsedNumber);

        // Update PlayerPrefs to save across app closes
        PlayerPrefs.SetInt(maxNumberKey, parsedNumber);
        PlayerPrefs.Save();
    }
}
