using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateBar2_3 : MonoBehaviour
{
    public Slider slider2_3;
    public Image fill2_3;
    public float currentVelocity2_3 = 0;

    public void SetMinAttack2_3(int attack)
    {
        slider2_3.minValue = attack;
        slider2_3.value = attack;
    }

    public void SetMaxAttack2_3(int attack)
    {
        slider2_3.maxValue = attack;
    }

    public void SetAttack2_3(int attack)
    {
        slider2_3.value = Mathf.SmoothDamp(slider2_3.value, attack, ref currentVelocity2_3, 0.12f);
    }
}
