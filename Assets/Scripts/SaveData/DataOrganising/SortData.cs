using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using SortType = DataVariables.SortTypes;

public class SortData : MonoBehaviour
{
    public void sortAcsendingByScore() {
        sortArray(new SortScoreAscending(), SortType.ScoreUp);
    }

    public void sortDescendingByScore() {
        sortArray(new SortScoreDescending(), SortType.ScoreDown);
    }

    public void sortDescendingByDate() {
        sortArray(new SortDateDescending(), SortType.DateDown);
    }

    public void sortAscendingByDate() {
        sortArray(new SortDateAscending(), SortType.DateUp);
    }

    public void sortDescendingByTime() {
        sortArray(new SortTimeDescending(), SortType.TimeDown);
    }

    public void sortAscendingByTime() {
        sortArray(new SortTimeAscending(), SortType.TimeUp);
    }

    public void sortDecsendingByName() {
        sortArray(new SortNameDescending(), SortType.NameDown);
    }

    public void sortAcsendingByName() {
        sortArray(new SortNameAscending(), SortType.NameUp);
    }

    void sortArray(IComparer comparer, SortType type) {
        SaveData data = DataManager.getSaveData();

        // Sort array by the given comparer, save the result to JSON
        Array.Sort(data.saveData, comparer);
        DataManager.save();
        
        LoadTable.instance.resetScoreboard();
    }
}
