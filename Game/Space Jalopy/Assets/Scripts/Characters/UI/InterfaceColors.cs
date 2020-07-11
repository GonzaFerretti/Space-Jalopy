using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "UI/InterfaceColors")]
public class InterfaceColorSettings : ScriptableObject
{
    public Color OkColor;
    public Color brokenColorStart;
    public Color brokenColorEnd;
    public Color beingRepairedColor;
    public Color baseArrowColor;
    public Color firstArrowColor;

    public float LerpTime;

}
