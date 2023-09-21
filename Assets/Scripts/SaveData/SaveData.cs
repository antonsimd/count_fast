using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveData
{
    public SaveGameInstance[] saveData;

    // Allows to dynamically set length of the array
    public SaveData(int numElements) {
        saveData = new SaveGameInstance[numElements];
    }
}

[Serializable]
public class SaveGameInstance
{
    public string gameMode;
    public int minNumber;
    public int maxNumber;
    public int timePerQuestion;
    public int score;
}
