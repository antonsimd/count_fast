using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadTable : MonoBehaviour
{
    [SerializeField] GameObject rowPrefab;
    [SerializeField] Transform parent;

    void Start() {
        DataManager.load();
        DataManager.clearData();

        initialiseData();

        var data = DataManager.getSaveData();
        createScoreboardEntries(data);
    }

    void createScoreboardEntries(SaveData data) {
        foreach(var gameData in data.saveData) {
            GameObject newRow = Instantiate(rowPrefab, parent);

            TextMeshProUGUI[] texts = newRow.GetComponentsInChildren<TextMeshProUGUI>();

            // HARD CODED, FIX IF NEEDED
            texts[0].text = gameData.gameMode + "\n" + "Min: " + gameData.minNumber.ToString() 
            + " Max: " + gameData.maxNumber.ToString();

            texts[1].text = gameData.timePerQuestion.ToString() + "S";
        }
    }

    void initialiseData() {
        SaveGameInstance temp = new SaveGameInstance();
        temp.gameMode = "Addition";
        temp.minNumber = 5;
        temp.maxNumber = 10;
        temp.timePerQuestion = 5;
        temp.score = 21;

        DataManager.addSavedGame(temp);
    }
}
