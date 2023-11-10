using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteIfNeeded : MonoBehaviour
{
    AudioSource audioSource;
    void Awake() {
        audioSource = gameObject.GetComponent<AudioSource>();
        initialise();
    }

    void initialise() {
        audioSource.mute = getMuteStatus() ? true : false;
    }

    bool getMuteStatus() {
        if (PlayerPrefs.HasKey(ButtonSound.soundPlayingKey)) {
            return PlayerPrefs.GetInt(ButtonSound.soundPlayingKey) == 1 ? true : false;
        } else {
            return false;
        }
    }
}
