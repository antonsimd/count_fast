using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject ScoreUp;
    [SerializeField] GameObject ScoreDown;
    [SerializeField] GameObject DateUp;
    [SerializeField] GameObject DateDown;
    [SerializeField] GameObject TimeUp;
    [SerializeField] GameObject TimeDown;
    [SerializeField] GameObject NameUp;
    [SerializeField] GameObject NameDown;

    public static ButtonManager instance;

    void Awake() {
        instance = this;
    }
    public void score() {
        flipObjects(ScoreDown, ScoreUp);
    }

    public void date() {
        flipObjects(DateDown, DateUp);
    }

    public void time() {
        flipObjects(TimeDown, TimeUp);
    }

    public void name() {
        flipObjects(NameDown, NameUp);
    }

    void flipObjects(GameObject a, GameObject b) {
        a.SetActive(false);
        b.SetActive(true);
    }
}
