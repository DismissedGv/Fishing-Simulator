using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    //private bool isFullscreen = true;
    public AudioMixer audioMixer;
    public Toggle fullscreenToggle;
    public Slider audioSlider;

    float volume;
    int fullscreenToggleInt;
    void Awake(){
        if(PlayerPrefs.HasKey("Fullscreen"))
        {
            Screen.fullScreen = PlayerPrefs.GetInt("Fullscreen") == 1 ? true:false;
        }
        else
        {
            Screen.fullScreen = true;
        }
        //Handle Audio Slider, if player has changed it before set it to the saved value, otherwise set it to half by default
        if (PlayerPrefs.HasKey("VolumeLevel"))
        {
            audioMixer.SetFloat("Volume", CalculateVolume(PlayerPrefs.GetFloat("VolumeLevel")));
            audioSlider.value = PlayerPrefs.GetFloat("VolumeLevel");
        }
        else
        {
            audioMixer.SetFloat("Volume", Mathf.Log10(0.5f * 20));
            audioSlider.value = 1;
        }
    }
    public void ToggleFullscreen()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
        fullscreenToggleInt = fullscreenToggle.isOn ? 1:0;
        Debug.Log("Fullscreen Toggle Int = " + fullscreenToggleInt);
        PlayerPrefs.SetInt("Fullscreen", fullscreenToggleInt);
        Debug.Log($"Fullscreen: {Screen.fullScreen}, expected: {fullscreenToggle.isOn}"); //Gonna have to try in a build as it doesn't seem to work in-engine
    }
    public void SetVolume(float value)
    {
        //Change volume level and save to PlayerPrefs
        audioMixer.SetFloat("Volume", CalculateVolume(value));
        volume = CalculateVolume(value);
        Debug.Log("Volume in dB "+ volume);
        PlayerPrefs.SetFloat("VolumeLevel", value);
        PlayerPrefs.Save();
    }
    public void ChangeResolution(int value){
        switch(value){
            case 0:
            Screen.SetResolution(1920,1080,fullscreenToggle.isOn);
            break;
            case 1:
            Screen.SetResolution(1366,768,fullscreenToggle.isOn);
            break;
            case 2:
            Screen.SetResolution(1280,720,fullscreenToggle.isOn);
            break;
        }
        Debug.Log(value);
    }
    private float CalculateVolume(float volume)
    {
        return Mathf.Log10(volume)*20;
    }
}
