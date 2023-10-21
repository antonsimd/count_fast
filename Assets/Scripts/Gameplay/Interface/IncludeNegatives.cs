using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncludeNegatives : MonoBehaviour
{
    const string includeNegativesKey = "includeNegatives";

    [SerializeField] Sprite notTicked;
    [SerializeField] Sprite ticked;
    [SerializeField] GameObject button;

    bool includeNegatives;
    Image image;

    void Start() {
        image = button.GetComponent<Image>();
        initialiseButton();
    }

    public void toggle() {
        includeNegatives = !includeNegatives;

        image.sprite = includeNegatives ? ticked : notTicked;
        Subtraction.setNegatives(includeNegatives);
        PlayerPrefs.SetInt(includeNegativesKey, includeNegatives ? 1 : 0);
        PlayerPrefs.Save();
    }

    void initialiseButton() {
        if (DifficultyInput.gameType != DifficultyInput.GameTypes.Subtraction) {
            gameObject.SetActive(false);
            return;
        }

        if (PlayerPrefs.HasKey(includeNegativesKey)) {
            includeNegatives = PlayerPrefs.GetInt(includeNegativesKey) == 1 ? true : false;

            if (includeNegatives) {
                image.sprite = ticked;
            } else {
                image.sprite = notTicked;
            }
        } else {
            includeNegatives = false;
            image.sprite = notTicked;
            PlayerPrefs.SetInt(includeNegativesKey, 0);
            PlayerPrefs.Save();
        }

        Subtraction.setNegatives(includeNegatives);
    }
}
