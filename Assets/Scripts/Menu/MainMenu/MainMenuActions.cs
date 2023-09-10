using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuActions : MonoBehaviour
{
    public static void additionGame() {
        MainGame.updateQuestionCreateFunction(Addition.generateQuestion);
        SceneManager.LoadScene("SelectDifficulty");
    }

    public static void multiplicationGame() {
        MainGame.updateQuestionCreateFunction(Multiplication.generateQuestion);
        SceneManager.LoadScene("MultDiv");
    }

    public static void subtractionGame() {
        MainGame.updateQuestionCreateFunction(Subtraction.generateQuestion);
        SceneManager.LoadScene("SelectDifficulty");
    }

    public static void divisionGame() {
        MainGame.updateQuestionCreateFunction(Division.generateQuestion);
        SceneManager.LoadScene("MultDiv");
    }

    public static void randomGame() {
        MainGame.updateQuestionCreateFunction(RandomGame.generateQuestion);
        SceneManager.LoadScene("SelectDifficulty");
    }
}
