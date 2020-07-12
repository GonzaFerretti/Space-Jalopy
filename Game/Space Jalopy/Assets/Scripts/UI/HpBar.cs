using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Image barFill;
    public Color emptyColor;
    public Color fullColor;
    public void ModifyHP(float amount)
    {
        barFill.fillAmount = amount;
        barFill.color = Color.Lerp(emptyColor, fullColor, amount);
    }
}
