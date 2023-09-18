using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TimeSelectSlider : MonoBehaviour
{
    [SerializeField] GameObject sliderObject;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI timeText;

    const string timeForEachQuestionKey = "timeForEachQuestion";
    const string TIME_TEXT_INITIAL = "Time for each question: ";
    const float DEFAULT_TIME = 5f;

    public static float timeForEachQuestion = DEFAULT_TIME;

    // Start is called before the first frame update
    void Start() {
        if (MainGame.gameMode == MainGame.GameModes.GAME) {
            initialiseTime();
        } else {
            sliderObject.SetActive(false);
        }
    }

    void initialiseTime() {
        sliderObject.SetActive(true);

        if (!PlayerPrefs.HasKey(timeForEachQuestionKey)) {
            PlayerPrefs.SetFloat(timeForEachQuestionKey, DEFAULT_TIME);
            PlayerPrefs.Save();
            timeForEachQuestion = DEFAULT_TIME;
        } else {
            timeForEachQuestion = PlayerPrefs.GetFloat(timeForEachQuestionKey);
        }

        slider.value = timeForEachQuestion;
        timeText.text = TIME_TEXT_INITIAL + timeForEachQuestion.ToString("0");

        // Update game slider with the current countdown time
        TimerSlider.setCountdownTimer(timeForEachQuestion);
    }

    public void updateValue(float newValue) {
        slider.value = newValue;
        timeText.text = TIME_TEXT_INITIAL + newValue.ToString("0");

        timeForEachQuestion = newValue;

        PlayerPrefs.SetFloat(timeForEachQuestionKey, timeForEachQuestion);
        PlayerPrefs.Save();
        
        // Update game slider with the current countdown time
        TimerSlider.setCountdownTimer(timeForEachQuestion);
    }
}
