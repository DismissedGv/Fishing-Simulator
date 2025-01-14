using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Toggle fullscreenToggle;
    public Slider audioSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    float volume;
    int fullscreenToggleInt;
    void Awake()
    {

        if (PlayerPrefs.HasKey("Fullscreen"))
        {
            Screen.fullScreen = PlayerPrefs.GetInt("Fullscreen") == 1 ? true : false;
        }
        else
        {
            Screen.fullScreen = true;
        }
        //Handle Audio Sliders, if player has changed any of them before set them to the saved value, otherwise set them to half by default
        if(audioSlider !=null && musicSlider !=null && sfxSlider !=null){
            SetupVolume();
        }
        else{
            audioSlider = GameObject.Find("MasterAudio").GetComponent<Slider>();
            musicSlider = GameObject.Find("MusicAudio").GetComponent<Slider>();
            sfxSlider = GameObject.Find("SFXAudio").GetComponent<Slider>();
            SetupVolume();
        }

    }

    private void SetupVolume()
    {
        #region Master
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            audioMixer.SetFloat("MasterVolume", CalculateVolume(PlayerPrefs.GetFloat("MasterVolume")));
            audioSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        }
        else
        {
            audioMixer.SetFloat("MasterVolume", Mathf.Log10(0.5f * 20));
            audioSlider.value = 0.5f;
        }
        #endregion
        #region Music
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            audioMixer.SetFloat("MusicVolume", CalculateVolume(PlayerPrefs.GetFloat("MusicVolume")));
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", Mathf.Log10(0.5f * 20));
            musicSlider.value = 0.5f;
        }
        #endregion
        #region SFX
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            audioMixer.SetFloat("SFXVolume", CalculateVolume(PlayerPrefs.GetFloat("SFXVolume")));
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }
        else
        {
            audioMixer.SetFloat("SFXVolume", Mathf.Log10(0.5f * 20));
            sfxSlider.value = 0.5f;
        }
        #endregion
    }

    public void ToggleFullscreen()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
        fullscreenToggleInt = fullscreenToggle.isOn ? 1 : 0;
        Debug.Log("Fullscreen Toggle Int = " + fullscreenToggleInt);
        PlayerPrefs.SetInt("Fullscreen", fullscreenToggleInt);
        Debug.Log($"Fullscreen: {Screen.fullScreen}, expected: {fullscreenToggle.isOn}"); //Gonna have to try in a build as it doesn't seem to work in-engine
    }
    public void SetMasterVolume(float value)
    {
        //Change volume level and save to PlayerPrefs
        audioMixer.SetFloat("MasterVolume", CalculateVolume(value));
        volume = CalculateVolume(value);
        Debug.Log("Volume in dB " + volume);
        PlayerPrefs.SetFloat("MasterVolume", value);
        PlayerPrefs.Save();
    }
    public void SetMusicVolume(float value){
        //Change volume level and save to PlayerPrefs
        audioMixer.SetFloat("MusicVolume", CalculateVolume(value));
        volume = CalculateVolume(value);
        Debug.Log("Volume in dB " + volume);
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();
    }
    public void SetSfxVolume(float value){
        //Change volume level and save to PlayerPrefs
        audioMixer.SetFloat("SFXVolume", CalculateVolume(value));
        volume = CalculateVolume(value);
        Debug.Log("Volume in dB " + volume);
        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();
    }
    public void ChangeResolution(int value)
    {
        switch (value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, fullscreenToggle.isOn);
                break;
            case 1:
                Screen.SetResolution(1366, 768, fullscreenToggle.isOn);
                break;
            case 2:
                Screen.SetResolution(1280, 720, fullscreenToggle.isOn);
                break;
        }
        Debug.Log(value);
    }
    private float CalculateVolume(float volume)
    {
        return Mathf.Log10(volume) * 20;
    }
}
