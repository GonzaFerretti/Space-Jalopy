using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartMovement : ShipPart
{
    public float time;
    public float timer;
    public float minForce;
    public float maxForce;
    public float minTime;
    public float maxTime;
    public Vector2 direction;
    public float disableTime;

    public void Update()
    {
        if (partStatus != repairState.isOk)
        {
            if (timer < time)
            {
                timer += Time.deltaTime;
            }
            else
            {

                time = Random.Range(minTime, maxTime);
                timer = 0;
                GlitchMove();
            }
        }
    }

    public void GlitchMove()
    {
        ship.SetMovementDisable(disableTime);
        float sign = Mathf.Sign(Random.Range(-1, 1));
        Vector2 glitchForce = Random.Range(minForce, maxForce) * direction * Time.deltaTime;
        ship.AddForce(glitchForce*sign);
    }
}
