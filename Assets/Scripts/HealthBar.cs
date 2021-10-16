using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text text;

    public void SetMaxHealth(int max)
    {
        slider.maxValue = max;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        text.text = health.ToString();
    }
}
