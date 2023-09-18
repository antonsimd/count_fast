using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerSlider : MonoBehaviour
{
    const float COLOR_LERP_TIME = 0.15f;
    const int COUNTDOWN_TIME_RATIO = 5;

    [SerializeField] Slider slider;
    [SerializeField] GameObject sliderFill;
    [SerializeField] Color greenColor;
    [SerializeField] Color redColor;

    public static TimerSlider instance;
    static float countdownTime = 5f;

    float timerValue;
    bool timerNeeded = false;
    Image sliderColor;

    public static void setCountdownTimer(float newTime) {
        countdownTime = newTime;
    }

    void Awake() {
        instance = this;
        sliderColor = sliderFill.GetComponent<Image>();
        gameObject.SetActive(false);
    }

    void Update() {
        if (timerNeeded) {
            slider.value = timerValue;
            timerValue -= Time.deltaTime;

            if (timerValue < countdownTime / COUNTDOWN_TIME_RATIO) {
                changeSliderColor();
            }
        }
    }

    void changeSliderColor() {
        sliderColor.color = Color.Lerp(sliderColor.color, redColor, COLOR_LERP_TIME);
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
