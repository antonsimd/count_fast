using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager: MonoBehaviour
{
    public SaveData data;

    string path;

    void Awake() {
        path = Application.persistentDataPath + "/" + "saveData.json";
        data = new SaveData();
    }

    public void save() {
        string json = JsonUtility.ToJson(data);
        Debug.Log("SAVING");
        writeToFile(json);
        // File.WriteAllText(path, json);
    }

    // public void load()
    // {
    //     if (File.Exists(path))
    //     {
    //         string loadSaveData = File.ReadAllText(path);
    //         data = JsonUtility.FromJson<SaveData>(loadSaveData);
    //         Debug.Log("LOADING");
    //         Debug.Log(data.saveData.Count);
    //     }
    //     else
    //         Debug.Log("There is no save files to load!");
    // }
  

    public void load() {
        data = new SaveData();
        string json = readFromFile();
        JsonUtility.FromJsonOverwrite(json, data);
        Debug.Log(data.saveData[0].gameMode);
    }

    void writeToFile(string json) {

        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream)) {
            writer.Write(json);
        }
    }

    string readFromFile() {
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
