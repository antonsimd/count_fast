using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public static float waitTime = 0.167f;

    [SerializeField] GameObject confirmPopupPrefab;
    [SerializeField] Animator transition;

    public void returnToMainMenu() {
        loadTransition("MainMenu");
    }

    public void confirmReturnToMainMenu() {
        string returnToMainMenuText = "return to main menu";
        ConfirmPopup.createPopup(confirmPopupPrefab, returnToMainMenuText, returnToMainMenu);
    }

    void loadTransition(string sceneName) {
        StartCoroutine(SceneLoaderCoroutine.loadTransition(sceneName, transition));
    }
}
