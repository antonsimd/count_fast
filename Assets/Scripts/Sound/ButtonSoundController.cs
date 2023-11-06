using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonSoundController : MonoBehaviour
{
    [SerializeField] Sprite inactive;
    [SerializeField] Sprite active;
    [SerializeField] ButtonSound buttonSound;

    Image image;
    bool muted;
    
    void Start() {
        image = gameObject.GetComponent<Image>();
        reset();
    }

    public void toggle() {
        muted = !muted;
        buttonSound.setMute(muted);
        reset();
    }

    void reset() {
        muted = buttonSound.getMuted();
        image.sprite = muted ? inactive : active;
        buttonSound.setMute(muted);
    }
}
