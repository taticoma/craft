using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsController : MonoBehaviour
{
    public Slider volSliderMusic;
    public TMP_Text volTextMusic;

    public Slider volSliderSound;
    public TMP_Text volTextSound;

    public AudioSource soundSource;
    public AudioSource musicSource;


    private void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        volSliderMusic.value = 1f;
        volSliderSound.value = 1f;
    }

    public void VolumeSliderMusic(float volume)
    {
        volTextMusic.text = volume.ToString("0.0");
        musicSource.volume = volSliderMusic.value;
    }

    public void VolumeSliderSound(float volume)
    {
        volTextSound.text = volume.ToString("0.0");
        soundSource.volume = volSliderSound.value;
    }

    public void OnPointerDown()
    {
        soundSource.Play();
    }


    public void SaveVolumeButton()
    {
        float volValueMusic = volSliderMusic.value;
        PlayerPrefs.SetFloat("VolumeValueMusic", volValueMusic);

        float volValueSound = volSliderSound.value;
        PlayerPrefs.SetFloat("VolumeValueSound", volValueSound);

        LoadValue();
    }

    public void LoadValue()
    {
        float volValueMusic = PlayerPrefs.GetFloat("VolumeValueMusic");
        float volValueSound = PlayerPrefs.GetFloat("VolumeValueSound");

        volSliderMusic.value = volValueMusic;
        AudioListener.volume = volValueMusic;

        volSliderSound.value = volValueSound;
        AudioListener.volume = volValueSound;
    }

  

}
