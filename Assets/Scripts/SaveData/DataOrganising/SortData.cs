using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SortData : MonoBehaviour
{
    public void sortAcsendingByScore() {
        sortArray(new SortScoreAscending());
    }

    public void sortDescendingByScore() {
        sortArray(new SortScoreDescending());
    }

    public void sortDescendingByDate() {
        sortArray(new SortDateDescending());
    }

    public void sortAscendingByDate() {
        sortArray(new SortDateAscending());
    }

    public void sortDescendingByTime() {
        sortArray(new SortTimeDescending());
    }

    public void sortAscendingByTime() {
        sortArray(new SortTimeAscending());
    }

    public void sortDecsendingByName() {
        sortArray(new SortNameDescending());
    }

    public void sortAcsendingByName() {
        sortArray(new SortNameAscending());
    }

    void sortArray(IComparer comparer) {
        SaveData data = DataManager.getSaveData();

        // Sort array by the given comparer, save the result to JSON
        Array.Sort(data.saveData, comparer);
        DataManager.save();
        
        LoadTable.instance.resetScoreboard();
    }
}
