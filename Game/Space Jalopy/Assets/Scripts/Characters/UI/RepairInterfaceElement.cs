using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairInterfaceElement : MonoBehaviour
{
    public InterfaceColorSettings colors;
    public Image img;
    public bool isBroken = false;
    public bool isLerpingForward = true;
    public float lerpStartTime;

    public void Start()
    {
        img = GetComponent<Image>();
    }

    public void Update()
    {
        if (isBroken)
        {
            BrokenColorLerp();
        }
    }

    public void BrokenColorLerp()
    {
        float currentTime = Time.time - lerpStartTime;
        float currentIndex = Mathf.InverseLerp(0, colors.LerpTime, currentTime);
        if (isLerpingForward)
        {
            img.color = Color.Lerp(colors.brokenColorStart, colors.brokenColorEnd, currentIndex);
        }
        else
        {
            img.color = Color.Lerp(colors.brokenColorEnd, colors.brokenColorStart, currentIndex);
        }
        if (currentIndex == 1)
        {
            isLerpingForward = !isLerpingForward;
            lerpStartTime = Time.time;
        }
    }
    public void UpdateStatus(repairState nextState)
    {
        switch (nextState)
        {
            case repairState.isOk:
                isBroken = false;
                img.color = colors.OkColor;
                break;
            case repairState.isBeingRepaired:
                isBroken = false;
                img.color = colors.beingRepairedColor;
                break;
            case repairState.isBroken:
                isBroken = true;
                lerpStartTime = Time.time;
                break;
        }
    }
}
