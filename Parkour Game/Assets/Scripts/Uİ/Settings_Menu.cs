using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings_Menu : MonoBehaviour
{
    public AudioMixer audiomix;

    private bool ÝsFullscreen = true;

    public void SetResoulation(int index)
    {
        if(index == 0)
        {
            Screen.SetResolution(1920, 1080 , ÝsFullscreen);
        }else if(index == 1)
        {
            Screen.SetResolution(1360, 768, ÝsFullscreen);
        }else if (index == 2)
        {
            Screen.SetResolution(800, 600, ÝsFullscreen);
        }
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool fullscreen_enable)
    {
        Screen.fullScreen = fullscreen_enable;
        ÝsFullscreen = fullscreen_enable;
    }

    public void SetMouseSensitivity(float value)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", value);

        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().mouseSensitivity = value;
        }
    }
     
    public void SetMasterVolume(float value)
    {
        audiomix.SetFloat("MasterVolume", value);
    }

    public void SetMusicVolume(float value)
    {
        audiomix.SetFloat("MusicVolume", value);
    }

}
