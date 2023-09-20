using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTable : MonoBehaviour
{
    [SerializeField] DataManager dataManager;

    void Start() {
        dataManager.load();
        // initialiseData();

        // dataManager.save();
        // dataManager.load();
    }

    void initialiseData() {
        SaveGameInstance temp = new SaveGameInstance();
        temp.gameMode = "Addition";
        temp.minNumber = 5;
        temp.maxNumber = 10;
        temp.timePerQuestion = 5;
        temp.score = 21;

        dataManager.data.saveData.SetValue(temp, 0);
    }
}
