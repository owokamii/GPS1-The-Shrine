using UnityEngine;
using UnityEngine.Events;

public class InteractObject : MonoBehaviour
{
    public UnityEvent _interactAction;
    public KeyCode _interactKey;
    public SpriteRenderer sprite;

    bool isTriggered = false;

    private bool _inRange;

    void Update()
    {
        if (_inRange)
        {
            if (Input.GetKeyDown(_interactKey))
            {
                sprite.enabled = false;
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
