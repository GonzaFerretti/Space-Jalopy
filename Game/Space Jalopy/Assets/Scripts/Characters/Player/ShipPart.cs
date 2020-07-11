using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPart : MonoBehaviour
{
    public repairState partStatus = repairState.isOk;
    public string displayName;
    public RepairInterfaceElement uiElement;
    public PlayerShip ship;
    public virtual void StartFix()
    {
        partStatus = repairState.isBeingRepaired;
        UpdateUI();
    }

    public virtual void Break()
    {
        partStatus = repairState.isBroken;
        UpdateUI();
    }

    public virtual void Fix()
    {
        partStatus = repairState.isOk;
        UpdateUI();
    }

    public void UpdateUI()
    {
        uiElement.UpdateStatus(partStatus);
    }
}

public enum repairState
{
    isBroken = 0,
    isBeingRepaired = 1,
    isOk = 2,
}
