using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainGame : MonoBehaviour
{

    public TextMeshProUGUI questionText;
    public static MainGame mainGame;

    // Min and max range for the numbers
    public (int, int) range = (1, 100);
    // Start is called before the first frame update
    void Awake() {
        mainGame = this;
    }

    void Start() {
        Addition.generateAdditionQuestion();
    }
}
