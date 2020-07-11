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
        if (canShoot)
        {
            base.Attack();
            if (!shoot.isBroken)
            {
                lastProjectile.transform.up = transform.up;
            }
            else
            {
                float angle = Random.Range(-shoot.angle, shoot.angle);
                lastProjectile.transform.up = Utilities.Rotate(transform.up, angle);
            }
        }
    }

    public override void Update()
    {
        base.Update();
    }
}
