using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class MultDiv : MonoBehaviour
{
    [SerializeField] GameObject minInput;
    [SerializeField] GameObject maxInput;

    const string minNumberKey = "minMDNumber";
    const string maxNumberKey = "maxMDNumber";
    const int DEFAULT_MIN = 0;
    const int DEFAULT_MAX = 20;

    // Variables for storing min and max inputs
    TMP_InputField minInputText;
    TMP_InputField maxInputText;


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
        Difficulty.setMinRange(parsedNumber);

        // Update PlayerPrefs to save across app closes
        PlayerPrefs.SetInt(minNumberKey, parsedNumber);
        PlayerPrefs.Save();
    }

    public void setMaxDifficulty() {
        int parsedNumber = Int32.Parse(maxInputText.text);
        Difficulty.setMaxRange(parsedNumber);

        // Update PlayerPrefs to save across app closes
        PlayerPrefs.SetInt(maxNumberKey, parsedNumber);
        PlayerPrefs.Save();
    }
}
