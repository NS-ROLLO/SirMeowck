using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    private float volume_;
    private int quality_;
    [SerializeField] Slider volumeSlider;
    [SerializeField] TMP_Dropdown qualityDropdown;
    public AudioMixer audioMixer;

    void Start()
    {
        volume_ = PlayerPrefs.GetFloat("lastVolume", -40f);
        SetVolume(volume_);
        volumeSlider.value = volume_;

        quality_ = PlayerPrefs.GetInt("lastQuality", 2);
        SetQuality(quality_);
        qualityDropdown.value = quality_;
        SaveSettings();
    }

    public void SetVolume(float vol)
    {
        audioMixer.SetFloat("volume", vol);
        volume_ = vol;
        Debug.Log("SetVolume button was pressed!!!!!!!" + vol);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        quality_ = qualityIndex;
        Debug.Log("SetQuality button was pressed!!!!!!!" + qualityIndex);

    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("fullScreen button was pressed!!!!!!!" + isFullscreen.ToString());


    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("lastQuality", quality_);
        PlayerPrefs.SetFloat("lastVolume", volume_);
    }
}
