using UnityEngine;

public class VaseSprite : MonoBehaviour
{
    public SpriteRenderer _currentSprite;
    //public Sprite _newSprite;

    private bool isTriggered;

    public void TriggerVase()
    {
        if(!isTriggered)
        {
            isTriggered = true;
            //_currentSprite.sprite = _newSprite;
            Destroy(gameObject);
        }
    }
}
