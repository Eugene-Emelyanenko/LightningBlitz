using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Slider soundSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider vibrationSlider;

    public float sound = 1f;
    public float music = 1f;
    public float vibration = 1f;

    private void Start()
    {
         sound = PlayerPrefs.GetFloat("sound", 1f);
         music = PlayerPrefs.GetFloat("music", 1f);
         vibration = PlayerPrefs.GetFloat("vibration", 1f);
         ApplySettings();
    }
    
    public void SoundSliderChangeValue(float value)
    {
        sound = value / 10f;
        ApplySettings();
    }

    public void MusicSliderChangeValue(float value)
    {
        music = value / 10f;
        ApplySettings();
    }
    
    public void VibrationSliderChangeValue(float value)
    {
        vibration = value / 10f;
        ApplySettings();
    }

    private void ApplySettings()
    {
        PlayerPrefs.SetFloat("sound", sound);
        PlayerPrefs.SetFloat("music", music);
        PlayerPrefs.SetFloat("vibration", vibration);

        soundSlider.value = sound * 10;
        musicSlider.value = music * 10;
        vibrationSlider.value = vibration * 10;

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
