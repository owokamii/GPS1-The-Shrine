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
    public bool isGlyphStone;

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
                _interactAction.Invoke();
                if (isWater)
                {
                    audioManager.PlaySFX(audioManager.sfx[5]);
                    sprite.enabled = false;
                    isTriggered = true;
                    _inRange = false;
                }
                if (isTrapdoor)
                {
                    audioManager.PlaySFX(audioManager.sfx[6]);
                    sprite.enabled = false;
                    isTriggered = true;
                    _interactAction.Invoke();
                }

                if (isGlyphStone)
                    audioManager.PlaySFX(audioManager.sfx[7]);

                _interactAction.Invoke();
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

    public void ResetWater()
    {
        isTriggered = false;
    }


}
