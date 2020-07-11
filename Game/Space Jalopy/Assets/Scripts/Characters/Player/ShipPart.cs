using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPart : MonoBehaviour
{
    public bool isBroken = false;
    public string displayName;
    public void Fix()
    {
        isBroken = true;
    }

    public void Break()
    {
        isBroken = false;
    }
}
