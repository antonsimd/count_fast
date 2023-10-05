using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadTable : MonoBehaviour
{
    [SerializeField] GameObject rowPrefab;
    [SerializeField] Transform parent;

    public static LoadTable instance;

    void Awake() {
        instance = this;
    }

    void Start() {
        resetScoreboard();
    }

    public void resetScoreboard() {
        clearRows();
        var data = DataManager.getSaveData();
        createScoreboardEntries(data);
    }

    public void clearScoreboard() {
        DataManager.clearData();
        clearRows();
        var data = DataManager.getSaveData();
        createScoreboardEntries(data);
    }

    void clearRows() {
        foreach(Transform child in parent) {
            GameObject.Destroy(child.gameObject);
        }
    }

    void createScoreboardEntries(SaveData data) {
        int i = 0;
        foreach(var gameData in data.saveData) {
            GameObject newRow = Instantiate(rowPrefab, parent);
            var script = newRow.GetComponent<TableRow>();
            script.setIndex(i);
            i++;

            TextMeshProUGUI[] texts = newRow.GetComponentsInChildren<TextMeshProUGUI>();

            // HARD CODED, FIX IF NEEDED
            // Game mode 
            texts[0].text = gameData.gameMode + "\n" + "Min: " + gameData.minNumber.ToString() 
            + " Max: " + gameData.maxNumber.ToString();

            // Time per question
            texts[1].text = gameData.timePerQuestion.ToString() + " S";
            // Score
            texts[2].text = gameData.score.ToString();
        }
    }

    void initialiseData() {
        SaveGameInstance temp = new SaveGameInstance();
        temp.gameMode = "Addition";
        temp.minNumber = 5;
        temp.maxNumber = 125;
        temp.timePerQuestion = 10;
        temp.score = 21;

        DataManager.addSavedGame(temp);
    }
}
