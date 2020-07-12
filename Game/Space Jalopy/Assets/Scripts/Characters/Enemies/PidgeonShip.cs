using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PidgeonShip : ClassicEnemyShip
{
    public float chargingTime;
    public float minShootTime;
    public float maxShootTime;

    public override void Start()
    {
        base.Start();
        projectileTime = Random.Range(minShootTime, maxShootTime);
    }

    public override void CheckProjectileTimer()
    {
        base.CheckProjectileTimer();
        if (projectileTimer > projectileTime - chargingTime)
        {
            baseMoveSpeed = 0;
        }
    }
}
