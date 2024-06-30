using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar2 : MonoBehaviour
{
    public Slider sliderr;
    public Image fill2;
    public float currentVelocityy = 0;

    public void SetMaxHealthh(int health)
    {
        sliderr.maxValue = health;
        sliderr.value = health;
    }

    public void SetHealthh(int health)
    {
        sliderr.value = Mathf.SmoothDamp(sliderr.value, health, ref currentVelocityy, 0.15f);
    }
}
