using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

using SortType = DataVariables.SortTypes;

public class SortData : MonoBehaviour
{
    const string sortedText = "Sorted By: ";

    [SerializeField] TextMeshProUGUI sortText;

    public static SortData instance;

    void Awake() {
        instance = this;
    }

    public void sortAcsendingByScore() {
        string text = "Score ↑";
        sortArray(new SortScoreAscending(), SortType.ScoreUp, text);
    }

    public void sortDescendingByScore() {
        string text = "Score ↓";
        sortArray(new SortScoreDescending(), SortType.ScoreDown, text);
    }

    public void sortDescendingByDate() {
        string text = "Date ↓";
        sortArray(new SortDateDescending(), SortType.DateDown, text);
    }

    public void sortAscendingByDate() {
        string text = "Date ↑";
        sortArray(new SortDateAscending(), SortType.DateUp, text);
    }

    public void sortDescendingByTime() {
        string text = "Time ↓";
        sortArray(new SortTimeDescending(), SortType.TimeDown, text);
    }

    public void sortAscendingByTime() {
        string text = "Time ↑";
        sortArray(new SortTimeAscending(), SortType.TimeUp, text);
    }

    public void sortDecsendingByName() {
        string text = "Game Type ↓";
        sortArray(new SortNameDescending(), SortType.NameDown, text);
    }

    public void sortAcsendingByName() {
        string text = "Game Type ↑";
        sortArray(new SortNameAscending(), SortType.NameUp, text);
    }

    void sortArray(IComparer comparer, SortType type, string text) {
        PlayerPrefs.SetString(DataVariables.sortTypeKey, type.ToString());

        sortText.text = sortedText + text;

        SaveData data = DataManager.getSaveData();
        if (data.saveData.Length == 0) {
            return;
        }

        // Sort array by the given comparer, save the result to JSON
        bubbleSort(data.saveData, comparer);
        DataManager.save();
        
        LoadTable.instance.resetScoreboard();
    }

    void bubbleSort(SaveGameInstance[] array, IComparer comparer) {
        int n = array.Length;
        bool swapped;

        for (int i = 0; i < n - 1; i++) {

            swapped = false;

            for (int j = 0; j < n - i - 1; j++) {
                if (comparer.Compare(array[j], array[j + 1]) == 1) {
                    var temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    swapped = true;
                }
            }

            if (!swapped) {
                break;
            }
        }
    }
}
