using UnityEngine;

public class TrapdoorSprite : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public SpriteRenderer _currentSprite;
    public Sprite _newSprite;

    private bool isTriggered;

    public void TriggerTrapdoor()
    {
        if(!isTriggered)
        {
            isTriggered = true;
            _currentSprite.sprite = _newSprite;
            boxCollider.enabled = false;
        }    
    }
}
