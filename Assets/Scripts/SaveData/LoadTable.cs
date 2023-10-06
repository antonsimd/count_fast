using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadTable : MonoBehaviour
{
    const string CLEAR_SCOREBOARD_TEXT = "clear the scoreboard";

    [SerializeField] GameObject rowPrefab;
    [SerializeField] Transform parent;
    [SerializeField] GameObject confirmSelectionPrefab;

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

    public void confirmClearScoreBoard() {
        ConfirmPopup.createPopup(confirmSelectionPrefab, CLEAR_SCOREBOARD_TEXT, clearScoreboard);
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
            // Date
            texts[0].text = gameData.date;
            // Game mode 
            texts[1].text = gameData.gameMode + "\n" + "Range: " + gameData.minNumber.ToString() 
            + " - " + gameData.maxNumber.ToString();

            // Time per question
            texts[2].text = gameData.timePerQuestion.ToString() + " S";
            // Score
            texts[3].text = gameData.score.ToString();
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
