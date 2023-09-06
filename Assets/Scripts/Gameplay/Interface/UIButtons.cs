using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public static void returnToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
