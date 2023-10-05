using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ConfirmPopup : MonoBehaviour
{
    const string areYouSureText = "Are you sure want to ";
    const string questionMark = "?";

    [SerializeField] TextMeshProUGUI questionText;

    // Function to be executed on confirm
    Action proceedFunction;

    public static void createPopup(GameObject prefab, string text, Action func) {
        // HARD CODED: finds Canvas by name
        GameObject canvas = GameObject.Find("Canvas");

        Vector3 initialPosition = new Vector3(0,0,0);
        GameObject gameObject = Instantiate(prefab, canvas.transform);
        
        // Make the panel a child of canvas object
        //gameObject.transform.parent = canvas.transform;

        ConfirmPopup newPopup = gameObject.GetComponent<ConfirmPopup>();
        newPopup.proceedFunction = func;
        newPopup.updateText(text);
    }

    void updateText(string text) {
        questionText.text = areYouSureText + text + questionMark;
    }

    public void confirmSelection() {
        proceedFunction();
        removePopup();
    }

    public void removePopup() {
        GameObject.Destroy(gameObject);
    }
}
