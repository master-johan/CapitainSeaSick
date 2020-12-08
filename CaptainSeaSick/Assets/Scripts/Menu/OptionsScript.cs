using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioMixer audioMixer;
    public AudioClip audioTest;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        float volume;
        GameAssets.instance.audioMixer.GetFloat("masterVolume", out volume);
        masterSlider.value = volume;
        GameAssets.instance.audioMixer.GetFloat("musicVolume", out volume);
        musicSlider.value = volume;
        GameAssets.instance.audioMixer.GetFloat("sfxVolume", out volume);
        sfxSlider.value = volume;
    }

    public void SetMasterVolume (float volume)
    {
        GameAssets.instance.audioMixer.SetFloat("masterVolume", volume);
        audioSource.PlayOneShot(audioTest, 1f);
    }
     public void SetMusicVolume (float volume)
    {
        GameAssets.instance.audioMixer.SetFloat("musicVolume", volume);
        audioSource.PlayOneShot(audioTest, 1f);
    }
     public void SetSFXVolume (float volume)
    {
        GameAssets.instance.audioMixer.SetFloat("sfxVolume", volume);
        audioSource.PlayOneShot(audioTest, 1f);
    }


}
