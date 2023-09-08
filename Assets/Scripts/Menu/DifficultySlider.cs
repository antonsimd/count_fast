using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultySlider : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI difficultyText;
    [SerializeField] Slider slider;

    const string DIFFICULTY_TEXT = "Difficulty: ";

    void Start() {
        int difficulty = Difficulty.getDifficulty();
        updateText((float)difficulty);
    }

    public void updateDifficulty(float value) {
        updateText(value);
        Difficulty.setDifficulty((int)value);
    }

    void updateText(float value) {
        slider.value = value;
        difficultyText.text = DIFFICULTY_TEXT + value.ToString("0");
    }
}
