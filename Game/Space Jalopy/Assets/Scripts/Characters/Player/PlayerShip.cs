using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : BaseShip
{
    public ShipPart[] ShipParts;
    public PartShield shield;
    public Rigidbody2D rb;
    public PartSteer steer;
    public PartThruster thruster;
    public PartShoot shoot;
    public PartRotate monoprop;

    public float projectileSpeed;

    public override void Start()
    {
        base.Start();
        ShipParts = GetComponentsInChildren<ShipPart>();
        rb = GetComponent<Rigidbody2D>();
    }
    public override void Attack()
    {
        if (canShoot)
        {
            base.Attack();
            if ((shoot.partStatus == repairState.isOk))
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

    public void Move(Vector2 vector)
    {
        rb.velocity = Vector2.zero;
        transform.position += new Vector3(vector.x, vector.y);
    }

    public void AddForce(Vector2 force)
    {
        rb.AddForce(force);
    }
}
