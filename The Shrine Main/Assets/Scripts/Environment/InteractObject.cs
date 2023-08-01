using UnityEngine;
using UnityEngine.Events;

public class InteractObject : MonoBehaviour
{
    public UnityEvent _interactAction;
    public KeyCode _interactKey;
    public SpriteRenderer sprite;

    bool isTriggered = false;

    private bool _inRange;

    AudioManager audioManager;

    public bool isWater;
    public bool isTrapdoor;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (_inRange)
        {
            if (Input.GetKeyDown(_interactKey))
            {
                sprite.enabled = false;
                if(isWater)
                    audioManager.PlaySFX(audioManager.sfx[5]);
                if (isTrapdoor)
                    audioManager.PlaySFX(audioManager.sfx[6]);
                _interactAction.Invoke();
                isTriggered = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Immortal"))
        {
            if(!isTriggered)
            {
                sprite.enabled = true;
                _inRange = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Immortal"))
        {
            sprite.enabled = false;
            _inRange = false;
        }
    }
}
