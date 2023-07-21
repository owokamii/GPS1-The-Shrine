using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    //public Audio[] audio;
    public AudioClip[] music;
    public AudioClip[] sfx;

    /*void Awake()
    {
        foreach (Audio a in audio)
        {
            a.musicSource = gameObject.AddComponent<AudioSource>();
            a.musicSource.clip = a.clip;

            a.musicSource.volume = a.volume;
            a.musicSource.pitch = a.pitch;
        }
    }*/

    /*public void Play(string name)
    {
        Audio a = Array.Find(audio, sound => sound.name == name);
        a.musicSource.Play();
    }*/

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
