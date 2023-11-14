using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButton : MonoBehaviour
{
    public static SkipButton instance;

    void Awake() {
        instance = this;
        gameObject.SetActive(false);
    }

    public void initialiseButton() {
        gameObject.SetActive(true);
    }

    public void skipQuestion() {
        MainGame.mainGame.generateNewQuestion();
    }
}
