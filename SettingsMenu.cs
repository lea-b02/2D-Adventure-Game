using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    //public float volume ;

    Resolution[] resolution;
    public TMP_Dropdown resolutionDropdown;

    public Slider musicSlider;
    public Slider soundEffectSlider;

    public void Start()
    {
        //audioMixer sans le out il renvoie un boolean
        audioMixer.GetFloat("Music", out float musicValueForSlider);
        musicSlider.value = musicValueForSlider;

        audioMixer.GetFloat("Sound Effect", out float soundEffectValueForSlider);
        soundEffectSlider.value = soundEffectValueForSlider;

        //resolution = Screen.resolutions
        //permette de pas a voir de duplication de resolution 
        resolution = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolution.Length; i++) {
            string opt = resolution[i].width + " x " + resolution[i].height;
            options.Add(opt);

            if (resolution[i].width == Screen.width && resolution[i].height == Screen.height) {
                currentResolutionIndex = i;
            }

        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        //Screen.fullScreen = true;

    }

    public void SetVolume(float volume)
    {
        if (audioMixer != null)
        {
            Debug.Log("on a change de volume: " + volume);
            audioMixer.SetFloat("Music", volume);
        }
        else
        {
            Debug.LogError("AudioMixer is not assigned!");
        }
    }

    public void SetSoundEffect(float volume)
    {
        if (audioMixer != null)
        {
            Debug.Log("on a change de volume: " + volume);
            audioMixer.SetFloat("Sound Effect", volume);
        }
        else
        {
            Debug.LogError("AudioMixer is not assigned!");
        }
    }

    public void SetFullScreen(bool isFullScreen) {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex) {
        Resolution resolutions = resolution[resolutionIndex];
        Screen.SetResolution(resolutions.width, resolutions.height, Screen.fullScreen);
    }

    public void ClearSavedDate() {
        PlayerPrefs.DeleteAll();
    }
}
