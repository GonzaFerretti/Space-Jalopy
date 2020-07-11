using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : BaseShip
{
    public ShipPart[] ShipParts;
    public PartShield shield;
    public PartSteer steer;
    public PartThruster thruster;
    public PartShoot shoot;
    public PartRotate monoprop;
    public float projectileSpeed;

    public override void Start()
    {
        base.Start();
        ShipParts = GetComponentsInChildren<ShipPart>();
    }
    public override void Attack()
    {
        base.Attack();
        lastProjectile.transform.up = transform.up;
    }
}
