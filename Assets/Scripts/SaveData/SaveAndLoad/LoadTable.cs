using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

using SortType = DataVariables.SortTypes;

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
        initialiseData();
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
            if (gameData.gameMode == "") {
                DataManager.removeAtIndex(i);
                continue;
            }

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
            texts[2].text = gameData.timePerQuestion.ToString() + "S";
            // Score
            texts[3].text = gameData.score.ToString();
        }
    }

    void initialiseData() {
        if (!PlayerPrefs.HasKey(DataVariables.sortTypeKey)) {
            resetScoreboard();
            return;
        }

        string typeString = PlayerPrefs.GetString(DataVariables.sortTypeKey);
        SortType type = Enum.Parse<SortType>(typeString);

        var sortData = SortData.instance;
        var buttonManager = ButtonManager.instance;

        switch (type) {
            case SortType.ScoreUp:
                sortData.sortAcsendingByScore();
                break;

            case SortType.ScoreDown:
                sortData.sortDescendingByScore();
                buttonManager.score();
                break;

            case SortType.DateUp:
                sortData.sortAscendingByDate();
                break;
                
            case SortType.DateDown:
                sortData.sortDescendingByDate();
                buttonManager.date();
                break;

            case SortType.TimeUp:
                sortData.sortAscendingByTime();
                break;

            case SortType.TimeDown:
                sortData.sortDescendingByTime();
                buttonManager.time();
                break;

            case SortType.NameUp:
                sortData.sortAcsendingByName();
                break;

            case SortType.NameDown:
                sortData.sortDecsendingByName();
                buttonManager.name();
                break;
        }
    }
}
