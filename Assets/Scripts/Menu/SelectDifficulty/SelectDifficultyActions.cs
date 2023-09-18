using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectDifficultyActions : MonoBehaviour
{
    public static void loadGame() {
        SceneManager.LoadScene("Game");
    }
}
