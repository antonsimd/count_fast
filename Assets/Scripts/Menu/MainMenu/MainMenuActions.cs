using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuActions : MonoBehaviour
{
    public static void additionGame() {
        MainGame.updateQuestionCreateFunction(Addition.generateQuestion);
        DifficultyInput.setGameMode(DifficultyInput.GameTypes.Addition);
        SceneManager.LoadScene("SelectDifficulty");
    }

    public static void multiplicationGame() {
        MainGame.updateQuestionCreateFunction(Multiplication.generateQuestion);
        DifficultyInput.setGameMode(DifficultyInput.GameTypes.Multiplication);
        SceneManager.LoadScene("SelectDifficulty");
    }

    public static void subtractionGame() {
        MainGame.updateQuestionCreateFunction(Subtraction.generateQuestion);
        DifficultyInput.setGameMode(DifficultyInput.GameTypes.Subtraction);
        SceneManager.LoadScene("SelectDifficulty");
    }

    public static void divisionGame() {
        MainGame.updateQuestionCreateFunction(Division.generateQuestion);
        DifficultyInput.setGameMode(DifficultyInput.GameTypes.Division);
        SceneManager.LoadScene("SelectDifficulty");
    }

    public static void randomGame() {
        MainGame.updateQuestionCreateFunction(RandomGame.generateQuestion);
        SceneManager.LoadScene("MixedDifficultySelection");
    }
}
