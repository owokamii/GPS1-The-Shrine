using UnityEngine;

public class VaseSprite : MonoBehaviour
{
    private bool isTriggered;

    public void TriggerVase()
    {
        if (!isTriggered)
            isTriggered = true;
    }
}
