using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveData
{
    public SaveGameInstance[] saveData = new SaveGameInstance[100];
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
