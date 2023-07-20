using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    public Audio[] musicc;
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
}
