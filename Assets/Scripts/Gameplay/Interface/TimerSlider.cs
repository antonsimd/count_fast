using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerSlider : MonoBehaviour
{
    [SerializeField] Slider slider;

    public static TimerSlider instance;
    static float countdownTime = 5f;

    float timerValue;
    bool timerNeeded = false;

    public static void setCountdownTimer(float newTime) {
        countdownTime = newTime;
    }

    void Awake() {
        instance = this;
        gameObject.SetActive(false);
    }

    void Update() {
        if (timerNeeded) {
            slider.value = timerValue;
            timerValue -= Time.deltaTime;
        }
    }

    // True if game is over
    // False otherwise
    public bool gameStatus() {
        return (timerValue <= 0);
    }

    public void stopTimer() {
        timerNeeded = false;
    }

    public void initialiseTimer() {
        gameObject.SetActive(true);
        slider.maxValue = countdownTime;
        timerNeeded = true;
        resetTimer();
    }

    public void resetTimer() {
        timerValue = countdownTime;
    }
}
