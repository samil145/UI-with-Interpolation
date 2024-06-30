using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateBar2_2 : MonoBehaviour
{
    public Slider slider2_2;
    public Image fill2_2;
    public float currentVelocity2_2 = 0;

    public void SetMinAttack2_2(int attack)
    {
        slider2_2.minValue = attack;
        slider2_2.value = attack;
    }

    public void SetMaxAttack2_2(int attack)
    {
        slider2_2.maxValue = attack;
    }

    public void SetAttack2_2(int attack)
    {
        slider2_2.value = Mathf.SmoothDamp(slider2_2.value, attack, ref currentVelocity2_2, 0.12f);
    }
}
