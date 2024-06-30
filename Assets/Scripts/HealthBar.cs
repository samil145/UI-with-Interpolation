using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public TMP_Text text;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public float currentVelocity = 0;

    private void Start()
    {
        text.text = "100";
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        health = health - 20 < 0 ? 0 : health-20;
        text.text = "" + (health);
        slider.value = Mathf.SmoothDamp(slider.value, health, ref currentVelocity, 0.15f);
        fill.color = gradient.Evaluate(slider.normalizedValue);
        
    }
}
