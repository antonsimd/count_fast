using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public static class DataManager
{
    const string NUM_ELEMENTS_KEY = "numElementsInSaveData";

    static int numElements = getNumElements();
    static SaveData data = new SaveData(numElements);

    static string path = Application.persistentDataPath + "/" + "saveData.json";

    public static void load() {
        string json = readFromFile();
        JsonUtility.FromJsonOverwrite(json, data);
    }

    // Add an instance of SaveGameInstance to the start of the array
    public static void addSavedGame(SaveGameInstance saveGameInstance) {

        // Get num elements from playerPrefs
        numElements = getNumElements();
        numElements++;

        // Update numElements in playerPrefs
        setNumElements(numElements);

        SaveData temp = new SaveData(numElements);
        temp.saveData[0] = saveGameInstance;
        data.saveData.CopyTo(temp.saveData, 1);
        data = temp;

        // Save changes to JSON
        save();
    }

    public static void removeAtIndex(int index) {
        // Get num elements from playerPrefs
        numElements = getNumElements();
        numElements--;

        // Update numElements in playerPrefs
        setNumElements(numElements);

        SaveData temp = new SaveData(numElements);
        int len = data.saveData.Length;
        bool removed = false;

        for (int i = 0; i < len; i++) {
            if (i == index) {
                removed = true;
                continue;
            }

            if (!removed) {
                temp.saveData[i] = data.saveData[i];
            } else {
                temp.saveData[i - 1] = data.saveData[i];
            }
        }

        data = temp;
        save();
    }

    public static SaveData getSaveData() {
        load();
        return data;
    }

    public static void clearData() {
        data = new SaveData(0);
        setNumElements(0);
        save();
    }

    // Save to JSON file
    public static void save() {
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

    // Get number of elements from PlayerPrefs
    // If key does not exist set it to 0 and return 0
    static int getNumElements() {
        if (!PlayerPrefs.HasKey(NUM_ELEMENTS_KEY)) {
            setNumElements(0);
            return 0;
        } else {
            return PlayerPrefs.GetInt(NUM_ELEMENTS_KEY);
        }
    }

    // Set num elements in PlayerPrefs
    static void setNumElements(int numElements) {
        PlayerPrefs.SetInt(NUM_ELEMENTS_KEY, numElements);
        PlayerPrefs.Save();
    }
}
