using UnityEngine;
using UnityEngine.Events;

public class InteractObject : MonoBehaviour
{
    public UnityEvent _interactAction;
    public KeyCode _interactKey;

    private bool _inRange;

    void Update()
    {
        if(_inRange)
            if(Input.GetKeyDown(_interactKey))
                _interactAction.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            _inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            _inRange = false;
    }
}
