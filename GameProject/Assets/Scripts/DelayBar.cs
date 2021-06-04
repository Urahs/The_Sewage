using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxValue(float maxValue){
        slider.maxValue = maxValue;
    }

    public void SetValue(float value){
        slider.value = value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void IncreaseValue(float value){
        slider.value += value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void ResetSlider(){
        slider.value = 0;
        fill.color = gradient.Evaluate(0);
    }

    public float GetValue(){
        return slider.value;
    }


}
