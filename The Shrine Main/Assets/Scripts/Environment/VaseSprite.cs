using UnityEngine;

public class VaseSprite : MonoBehaviour
{
    public bool toDestroy = false;
    private bool isTriggered;

    public void TriggerVase()
    {
        if(!isTriggered)
            if(toDestroy)
            {
                isTriggered = true;
                Destroy(gameObject);
            }
    }
}
