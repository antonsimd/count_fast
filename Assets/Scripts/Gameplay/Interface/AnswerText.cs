using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerText : MonoBehaviour
{
    public float DURATION = 0.3f;
    public Color correctColor;

    Image image;
    public static AnswerText instance;

    void Awake() {
        instance = this;
    }

    void Start() {
        image = gameObject.GetComponent<Image>();
    }

    public void correctAnswer() {
        StartCoroutine(DamageEffectSequence(correctColor));
    }

    IEnumerator DamageEffectSequence(Color changedColor) {
    // save origin color
        Color originColor = image.color;

        // tint the sprite with damage color
        image.color = changedColor;

        // lerp animation with given duration in seconds
        for (float t = 0; t < 1.0f; t += Time.deltaTime / DURATION)
        {
            image.color = Color.Lerp(changedColor, originColor , t);

            yield return null;
        }

        // restore origin color
        image.color = originColor;
    }
}
