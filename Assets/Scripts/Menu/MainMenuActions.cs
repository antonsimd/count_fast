using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuActions : MonoBehaviour
{
    public static void additionGame() {
        MainGame.updateQuestionCreateFunction(Addition.generateAdditionQuestion);
        SceneManager.LoadScene("Game");
    }
}
