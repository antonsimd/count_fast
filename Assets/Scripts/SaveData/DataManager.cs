using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public static class DataManager
{
    static int numElements = 0;
    static SaveData data = new SaveData(numElements);

    static string path = Application.persistentDataPath + "/" + "saveData.json";

    public static void load() {
        string json = readFromFile();
        JsonUtility.FromJsonOverwrite(json, data);
    }

    public static void addSavedGame(SaveGameInstance saveGameInstance) {

        // Add an instance of SaveGameInstance to the start of the array
        numElements++;
        SaveData temp = new SaveData(numElements);
        temp.saveData[0] = saveGameInstance;
        data.saveData.CopyTo(temp.saveData, 1);
        data = temp;

        // Save changes to JSON
        save();
    }

    public static SaveData getSaveData() {
        return data;
    }

    public static void clearData() {
        data = new SaveData(0);
        save();
    }

    // Save to JSON file
    static void save() {
        string json = JsonUtility.ToJson(data);
        writeToFile(json);
    }

    static void writeToFile(string json) {

        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream)) {
            writer.Write(json);
        }
    }

    static string readFromFile() {
        string json = "";

        if (File.Exists(path)) {
            using (StreamReader reader = new StreamReader(path)) {
                json = reader.ReadToEnd();
            }
        } else {
            Debug.Log("File not found!");
        }

        return json;
    }
}
