using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameModeChanges : MonoBehaviour
{
    const string gameModeKey = "gameMode";

    [SerializeField] GameObject onButton;
    [SerializeField] GameObject offButton;

    void Awake() {
        if (!PlayerPrefs.HasKey(gameModeKey)) {
            PlayerPrefs.SetInt(gameModeKey, (int)MainGame.GameModes.PRACTICE);
            PlayerPrefs.Save();
            changeGameMode(MainGame.GameModes.PRACTICE.ToString());
        } else {
            int index = PlayerPrefs.GetInt(gameModeKey);
            var parsedGameMode = (MainGame.GameModes)index;
            changeGameMode(parsedGameMode.ToString());
        }
    }

    public void changeGameMode(string newGameMode) {
        var parsedGameMode = Enum.Parse<MainGame.GameModes>(newGameMode);
        PlayerPrefs.SetInt(gameModeKey, (int)parsedGameMode);
        PlayerPrefs.Save();
        updateButton(parsedGameMode);
        MainGame.changeGameMode(parsedGameMode);
    }

    void updateButton(MainGame.GameModes gameMode) {
        if (gameMode == MainGame.GameModes.PRACTICE) {
            onButton.SetActive(true);
            offButton.SetActive(false);
        } else if (gameMode == MainGame.GameModes.GAME) {
            onButton.SetActive(false);
            offButton.SetActive(true);
        }
    }
}
