using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D _effector;
    public float _waitTime;

    void Start()
    {
        _effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.S))
        {
            _waitTime = 0.5f;
        }

        if(Input.GetKey(KeyCode.S))
        {
            if(_waitTime <= 0)
            {
                _effector.rotationalOffset = 180f;
                _waitTime = 0.5f;
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
        }

        if(Input.GetKey(KeyCode.W))
        {
            _effector.rotationalOffset = 0;
        }
    }
}
