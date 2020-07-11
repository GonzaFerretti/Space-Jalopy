using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : BaseProjectile
{
    public override void Init(BaseShip firingShip)
    {
        speed = (firingShip as PlayerShip).projectileSpeed;
    }

    public override void Move()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
