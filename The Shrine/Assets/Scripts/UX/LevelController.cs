using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] FlashImage _flashImage = null;
    [SerializeField] Color _newColor = Color.red;
    [SerializeField] private AudioSource heartbeatSoundEffect;

    private PlayerHealth _playerHealth; // Reference to the PlayerHealth component
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _playerHealth = FindObjectOfType<PlayerHealth>(); // Find the PlayerHealth component in the scene
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckThirstAndFlash", 0f, 4f);
    }

    // Method to check thirst and trigger the flash effect
    private void CheckThirstAndFlash()
    {
        if (_playerHealth != null && _playerHealth._currentThirst <= 40)
        {
            audioManager.PlaySFX(audioManager.sfx[9]);
            _flashImage.StartFlash(.5f, .5f, _newColor);
        }
    }
}
