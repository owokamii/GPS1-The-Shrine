using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    public AudioClip[] music;
    public AudioClip[] sfx;

    private void Start()
    {
        musicSource.clip = music[0];
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlaySFXLoop(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
        sfxSource.loop = true;
    }
}
