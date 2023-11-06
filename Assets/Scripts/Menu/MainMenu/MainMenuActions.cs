using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuActions : MonoBehaviour
{
    [SerializeField] Animator transition;

    public void additionGame() {
        MainGame.updateQuestionCreateFunction(Addition.generateQuestion);
        DifficultyInput.setGameMode(DifficultyInput.GameTypes.Addition);
        loadTransition();
    }

    public void multiplicationGame() {
        MainGame.updateQuestionCreateFunction(Multiplication.generateQuestion);
        DifficultyInput.setGameMode(DifficultyInput.GameTypes.Multiplication);
        loadTransition();
    }

    public void subtractionGame() {
        MainGame.updateQuestionCreateFunction(Subtraction.generateQuestion);
        DifficultyInput.setGameMode(DifficultyInput.GameTypes.Subtraction);
        loadTransition();
    }

    public void divisionGame() {
        MainGame.updateQuestionCreateFunction(Division.generateQuestion);
        DifficultyInput.setGameMode(DifficultyInput.GameTypes.Division);
        loadTransition();
    }

    public void randomGame() {
        MainGame.updateQuestionCreateFunction(RandomGame.generateQuestion);
        loadTransition("MixedDifficultySelection");
    }

    public void viewScoreboard() {
        loadTransition("SavedScores");
    }

    void loadTransition(string sceneName = "SelectDifficulty") {
        StartCoroutine(SceneLoaderCoroutine.loadTransition(sceneName, transition));
    }
}
