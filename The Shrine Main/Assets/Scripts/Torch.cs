using UnityEngine;

public class Torch : MonoBehaviour
{
    public SpriteRenderer sp;
    public Sprite litTorch;

    void Update()
    {
        if(Input.GetButtonDown("Interact"))
        {
            sp.sprite = litTorch;
        }
    }
}
