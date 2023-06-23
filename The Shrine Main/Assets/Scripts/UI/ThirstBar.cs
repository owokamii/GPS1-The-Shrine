using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirstBar : MonoBehaviour
{
    public Slider slider;
    
    public void SetMaxThirst(float thirst)
    {
        slider.maxValue = thirst;
        slider.value = thirst;
    }

    public void SetThirst(float thirst)
    {
        slider.value = thirst;
    }
}