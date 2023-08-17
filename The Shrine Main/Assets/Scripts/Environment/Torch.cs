using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Torch : MonoBehaviour
{
    public ParticleSystem fire;
    public SpriteRenderer currentSprite;
    public Sprite litTorch;
    public Sprite unlitTorch;

    private Light2D torchLight;
    public bool isTriggered;

    void Start()
    {
        torchLight = GetComponent<Light2D>();
    }

    public void TriggerTorch()
    {
        if (!isTriggered)
        {
            isTriggered = true;
            LightUpTorch();
            currentSprite.sprite = litTorch;
            torchLight.enabled = true;

        }
        else
        {
            isTriggered = false;
            PutOutTorch();
            currentSprite.sprite = unlitTorch;
            torchLight.enabled = false;
        }
            
    }

    void LightUpTorch()
    {
        fire.Play();
    }

    void PutOutTorch()
    {
        fire.Stop();
    }
}
