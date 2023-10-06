using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SortData : MonoBehaviour
{
    public void sortAcsendingByScore() {
        SaveData data = DataManager.getSaveData();

        // Sort array by ascending score, save the result to JSON
        Array.Sort(data.saveData, new SortScoreAscending());
        DataManager.save();
        
        LoadTable.instance.resetScoreboard();
    }
}
