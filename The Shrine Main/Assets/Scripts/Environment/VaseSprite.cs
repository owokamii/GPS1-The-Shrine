using UnityEngine;

public class VaseSprite : MonoBehaviour
{
    public SpriteRenderer _currentSprite;

    private bool isTriggered;

    public void TriggerVase()
    {
        if(!isTriggered)
        {
            isTriggered = true;
            Destroy(gameObject);
        }
    }
}
