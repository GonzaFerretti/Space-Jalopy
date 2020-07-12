using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Image barFill;
    public void ModifyHP(float amount)
    {
        barFill.fillAmount = amount;
    }
}
