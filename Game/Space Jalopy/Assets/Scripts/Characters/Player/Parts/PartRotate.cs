using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartRotate : ShipPart
{
    public float angle;
    public float arcTime;
    public float startTime;
    public bool goingRight = true;
    private void Update()
    {
        if (partStatus == repairState.isBroken)
        {
            float currentTime = Time.time - startTime;
            float currentIndex = Mathf.InverseLerp(0,arcTime,currentTime);
            float currentAngle = 0;
            if (goingRight)
            {
                currentAngle = Mathf.Lerp(-angle / 2, angle / 2, currentIndex);
            }
            else
            {
                currentAngle = Mathf.Lerp(angle / 2, -angle / 2, currentIndex);
            }
            if (currentIndex == 1)
            {
                goingRight = !goingRight;
                startTime = Time.time;
            }
            ship.transform.up = Utilities.Rotate(Vector2.up, currentAngle);
        }
    }

    public override void Break()
    {
        base.Break();
        startTime = Time.time;
    }

    public override void Fix()
    {
        base.Fix();
        goingRight = false;
        ship.transform.up = Vector2.up;
    }
}
