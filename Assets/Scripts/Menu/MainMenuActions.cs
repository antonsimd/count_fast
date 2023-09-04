using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuActions : MonoBehaviour
{
    public static void additionGame() {
        MainGame.updateQuestionCreateFunction(Addition.generateQuestion);
        SceneManager.LoadScene("Game");
    }

    public static void multiplicationGame() {
        MainGame.updateQuestionCreateFunction(Multiplication.generateQuestion);
        SceneManager.LoadScene("Game");
    }

    public static void subtractionGame() {
        MainGame.updateQuestionCreateFunction(Subtraction.generateQuestion);
        SceneManager.LoadScene("Game");
    }

    public static void divisionGame() {
        MainGame.updateQuestionCreateFunction(Division.generateQuestion);
        SceneManager.LoadScene("Game");
    }

    public static void randomGame() {
        MainGame.updateQuestionCreateFunction(RandomGame.generateQuestion);
        SceneManager.LoadScene("Game");
    }
}
