using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSoundSettings : MonoBehaviour
{
    public float sound = 1f;
    public float music = 1f;
    public float vibration = 1f;
    void Start()
    {
        sound = PlayerPrefs.GetFloat("sound", 1f);
        music = PlayerPrefs.GetFloat("music", 1f);
        vibration = PlayerPrefs.GetFloat("vibration", 1f);
        ApplySettings();
    }

    private void ApplySettings()
    {
        Sound[] sounds = FindObjectOfType<AudioManager>().sounds;
        Sound s = Array.Find(sounds, sound => sound.name == "Theme");
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = music;

        AudioListener.volume = sound;
    }
}
