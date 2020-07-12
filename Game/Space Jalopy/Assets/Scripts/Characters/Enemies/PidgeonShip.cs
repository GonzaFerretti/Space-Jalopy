using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PidgeonShip : ClassicEnemyShip
{
    public float chargingTime;
    public float minShootTime;
    public float maxShootTime;
    public float usualBaseSpeed;
    public bool isStopped = false;

    public override void Start()
    {
        base.Start();
        projectileTime = Random.Range(minShootTime, maxShootTime);
    }

    public override void CheckProjectileTimer()
    {
        base.CheckProjectileTimer();
        if (projectileTimer > projectileTime - chargingTime && !isStopped)
        {
            anim.SetBool("open", true);
            isStopped = true;
            baseMoveSpeed = 0;
        }
    }
}
