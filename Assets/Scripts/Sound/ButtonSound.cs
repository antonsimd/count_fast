using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public static string soundPlayingKey = "soundPlaying";
    AudioSource musicPlayer;
    bool muted;

    void Awake() {
        musicPlayer = gameObject.GetComponent<AudioSource>();
        initialise();
    }

    public bool getMuted() {
        return muted;
    }

    public void setMute(bool value) {
        muted = value;
        setPlayerPrefs(value);
        musicPlayer.mute = value;
    }

    void setPlayerPrefs(bool value) {
        PlayerPrefs.SetInt(soundPlayingKey, value ? 1 : 0);
        PlayerPrefs.Save();
    }

    void initialise() {
        muted = getPlayerPrefs();
        musicPlayer.mute = muted;
    }

    bool getPlayerPrefs() {
        bool isMuted = false;

        if (PlayerPrefs.HasKey(soundPlayingKey)) {
            isMuted = PlayerPrefs.GetInt(soundPlayingKey) == 1 ? true : false;
        } else {
            setPlayerPrefs(false);
        }

        return isMuted;
    }
}
