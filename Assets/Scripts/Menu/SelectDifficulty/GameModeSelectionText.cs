using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameModeSelectionText : MonoBehaviour
{
    const string GAME_MODE_TEXT = "Game mode: ";
    [SerializeField] TextMeshProUGUI GameModeText;

    void Start() {
        GameModeText.text = GAME_MODE_TEXT + DifficultyInput.gameType.ToString();
    }
}
