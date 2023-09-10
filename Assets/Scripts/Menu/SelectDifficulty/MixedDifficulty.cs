using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixedDifficulty : MonoBehaviour
{
    [SerializeField] GameObject ASPanel;
    [SerializeField] GameObject MDPanel;

    void Start() {
        setASMode();
    }

    public void setASMode() {
        DifficultyInput.setGameMode(DifficultyInput.GameTypes.Addition);
        ASPanel.SetActive(true);
        MDPanel.SetActive(false);
    }

    public void setMDMode() {
        DifficultyInput.setGameMode(DifficultyInput.GameTypes.Multiplication);
        ASPanel.SetActive(false);
        MDPanel.SetActive(true);
    }
}