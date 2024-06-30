using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateBar2_1 : MonoBehaviour
{
    public Slider slider2_1;
    public Image fill2_1;
    public float currentVelocity2_1 = 0;

    public void SetMinAttack2_1(int attack)
    {
        slider2_1.minValue = attack;
        slider2_1.value = attack;
    }

    public void SetMaxAttack2_1(int attack)
    {
        slider2_1.maxValue = attack;
        
    }

    public void SetAttack2_1(int attack)
    {
        slider2_1.value = Mathf.SmoothDamp(slider2_1.value, attack, ref currentVelocity2_1, 0.12f);
    }
}
