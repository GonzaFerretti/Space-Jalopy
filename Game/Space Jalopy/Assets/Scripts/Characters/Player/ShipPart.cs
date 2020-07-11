using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPart : MonoBehaviour
{
    public bool isBroken = false;
    public string displayName;
    public PlayerShip ship;
    public virtual void Fix()
    {
        isBroken = false;
    }

    public virtual void Break()
    {
        isBroken = true;
    }
}
