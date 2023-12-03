using UnityEngine;
using UnityEngine.UI;

public class ThirstBar : MonoBehaviour
{
    public Slider _slider;
    
    public void SetMaxThirst(float _thirst)
    {
        _slider.maxValue = _thirst;
        _slider.value = _thirst;
    }

    public void SetThirst(float _thirst)
    {
        _slider.value = _thirst;
    }
}