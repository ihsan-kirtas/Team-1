using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class JH_SettingsMenuUI : MonoBehaviour
{
    //public AudioMixer audioMixer;                           //Audio hasn't been set up yet but the scripting for the functionality is set to be implemented - this hasn't been tested

    Resolution[] resolutions;

    public Dropdown resolutionDropdown;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        //For method of volume using linear value (-80 to 0)
        //audioMixer.SetFloat("volume", volume);                    //The name in the brackets "" is the name of the exposed parameter in the Audio Mixer

        //For method of volume using logarithmic value (0.0001 to 1)
        //audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);  //Found this at: https://www.youtube.com/watch?v=xNHSGMKtlv4
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("Fullscreen toggle test");
    }
}
