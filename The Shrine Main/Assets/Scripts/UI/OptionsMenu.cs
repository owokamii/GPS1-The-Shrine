using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;

    private void Start()
    {
        if(PlayerPrefs.HasKey("masterVolume"))
            LoadMasterVolume();
        if(PlayerPrefs.HasKey("musicVolume"))
            LoadMusicVolume();
        if(PlayerPrefs.HasKey("sfxVolume"))
            LoadSFXVolume();
    }

    public void SetMasterVolume()
    {
        float volume = masterVolumeSlider.value;
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume()
    {
        float volume = musicVolumeSlider.value;
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = sfxVolumeSlider.value;
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    private void LoadMasterVolume()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
        SetMasterVolume();
    }

    private void LoadMusicVolume()
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicVolume();
    }

    private void LoadSFXVolume()
    {
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        SetSFXVolume();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
