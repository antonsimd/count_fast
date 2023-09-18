using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class PlayButton : MonoBehaviour
{
    [SerializeField] GameObject errorText;
    
    [SerializeField] GameObject minInput;
    [SerializeField] GameObject maxInput;

    Button button;
    TMP_InputField minInputText;
    TMP_InputField maxInputText;

    void Start() {
        minInputText = minInput.GetComponent<TMP_InputField>();
        maxInputText = maxInput.GetComponent<TMP_InputField>();
        button = gameObject.GetComponent<Button>();

        errorText.SetActive(false);
    }

    void Update() {
        if (Int32.Parse(minInputText.text) > Int32.Parse(maxInputText.text)) {
            errorText.SetActive(true);
            button.interactable = false;
        } else {
            errorText.SetActive(false);
            button.interactable = true;
        }
    }

}
