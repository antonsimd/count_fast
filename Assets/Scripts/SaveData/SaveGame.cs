using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public void saveGame() {
        var newSave = new SaveGameInstance();
        newSave.gameMode = DifficultyInput.gameType.ToString();

        // Set min and max values        
        if (DifficultyInput.gameType == DifficultyInput.GameTypes.Addition || DifficultyInput.gameType == DifficultyInput.GameTypes.Subtraction) {
            newSave.minNumber = Difficulty.range.Item1;
            newSave.maxNumber = Difficulty.range.Item2;

            // if game mode is mixed, set min as the min number between addition and multiplication 
            // and max as the max number
        } else if (DifficultyInput.gameType == DifficultyInput.GameTypes.Mixed) {
            newSave.minNumber = Difficulty.MDRange.Item1 < Difficulty.range.Item1 ? Difficulty.MDRange.Item1 : Difficulty.range.Item1;
            newSave.maxNumber = Difficulty.MDRange.Item2 > Difficulty.range.Item2 ? Difficulty.MDRange.Item2 : Difficulty.range.Item2;
        } else {
            newSave.minNumber = Difficulty.MDRange.Item1;
            newSave.maxNumber = Difficulty.MDRange.Item2;
        }

        // Decrease by 1 due to the highest number being excluded in random number generation
        newSave.maxNumber--;

        newSave.timePerQuestion = (int)TimeSelectSlider.timeForEachQuestion;
        newSave.score = Score.instance.getScore();

        // Add data to save file
        DataManager.addSavedGame(newSave);
    }
}
