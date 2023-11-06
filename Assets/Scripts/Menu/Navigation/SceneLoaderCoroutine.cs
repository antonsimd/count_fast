using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderCoroutine
{
    const string transitionTrigger = "Start";

    public static IEnumerator loadTransition(string sceneName, Animator transition) {
        transition.SetTrigger(transitionTrigger);

        yield return new WaitForSeconds(UIButtons.waitTime);

        SceneManager.LoadScene(sceneName);
    }
}
