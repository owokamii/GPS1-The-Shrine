using UnityEngine;

public class VaseSprite : MonoBehaviour
{
    public PlayerHealth _playerHealth;
    public SpriteRenderer _currentSprite;
    public Sprite _newSprite;

    private bool isTriggered;

    void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    public void TriggerVase()
    {
        if(!isTriggered)
        {
            isTriggered = true;
            _currentSprite.sprite = _newSprite;
            Debug.Log("vase sprite changed");
            _playerHealth.Hydration(10);
        }
    }
}
