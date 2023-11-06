using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    const string musicPlayerName = "MusicPlayer";
    const string musicPlayingKey = "musicPlaying";

    [SerializeField] Sprite inactive;
    [SerializeField] Sprite active;
    [SerializeField] GameObject musicPlayerPrefab;
    
    AudioSource musicPlayer;
    bool playing;
    Image image;

    void Start() {
        image = gameObject.GetComponent<Image>();
        initialise();
    }

    public void toggle() {
        playing = !playing;

        updateButtonAndObject();

        PlayerPrefs.SetInt(musicPlayingKey, playing ? 1 : 0);
        PlayerPrefs.Save();
    }

    void initialise() {
        if (PlayerPrefs.HasKey(musicPlayingKey)) {
            playing = PlayerPrefs.GetInt(musicPlayingKey) == 1 ? true : false;
        } else {
            playing = true;
            PlayerPrefs.SetInt(musicPlayingKey, 1);
            PlayerPrefs.Save();
        }

        createObject();
        updateButtonAndObject();
    }

    void updateButtonAndObject() {
        if (playing) {
            image.sprite = active;
            musicPlayer.mute = false;
        } else {
            image.sprite = inactive;
            musicPlayer.mute = true;
        }
    }

    void createObject() {
        var musicPlayerObject = GameObject.Find(musicPlayerName);
        musicPlayerObject = musicPlayerObject == null ? Instantiate(musicPlayerPrefab) : musicPlayerObject;
        musicPlayerObject.name = musicPlayerName;
        musicPlayer = musicPlayerObject.GetComponent<AudioSource>();
    }
}
