using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    [SerializeField] GameObject confirmPopupPrefab;

    public static void returnToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void confirmReturnToMainMenu() {
        string returnToMainMenuText = "return to main menu";
        ConfirmPopup.createPopup(confirmPopupPrefab, returnToMainMenuText, returnToMainMenu);
    }
}
