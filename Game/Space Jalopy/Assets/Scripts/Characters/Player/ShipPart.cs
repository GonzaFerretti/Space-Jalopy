using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPart : MonoBehaviour
{
    public repairState partStatus = repairState.isOk;
    public string displayName;
    public RepairInterfaceElement uiElement;
    public PlayerShip ship;
    public virtual void Fix()
    {
        partStatus = repairState.isBeingRepaired;
        uiElement.UpdateStatus(repairState.isBeingRepaired);
    }

    public virtual void Break()
    {
        partStatus = repairState.isBroken;
        uiElement.UpdateStatus(repairState.isBroken);
    }
}

public enum repairState
{
    isBroken = 0,
    isBeingRepaired = 1,
    isOk = 2,
}
