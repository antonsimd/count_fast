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
    CanvasGroup canvasGroup;

    // Function to be executed on confirm
    Action proceedFunction;
    static bool destructionNeeded = false;

    void Start() {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
    }

    public static void createPopup(GameObject prefab, string text, Action func) {
        destructionNeeded = false;
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

    public static void destroyPopupIfNeeded() {
        destructionNeeded = true;
    }

    void Update() {
        if (destructionNeeded) {
            removePopup();
        }
    }

    void updateText(string text) {
        questionText.text = areYouSureText + text + questionMark;
    }

    public void confirmSelection() {
        canvasGroup.alpha = 0;
        removePopup();
        proceedFunction();
    }

    public void removePopup() {
        StartCoroutine(removePopupDelay());
    }

    IEnumerator removePopupDelay() {
        yield return new WaitForSeconds(UIButtons.waitTime);

        GameObject.Destroy(gameObject);
    }
}
