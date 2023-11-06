using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectDifficultyActions : MonoBehaviour
{
    [SerializeField] Animator transition;

    public void loadGame() {
        StartCoroutine(SceneLoaderCoroutine.loadTransition("Game", transition));
    }
}
