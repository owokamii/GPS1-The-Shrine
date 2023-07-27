using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Animator _animator;
    AudioManager audioManager;
    bool activated = false;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(activated == false)
        {
            activated = true;
            _animator.SetBool("Activated", true);
            audioManager.PlaySFX(audioManager.sfx[3]);
        }
    }
}
