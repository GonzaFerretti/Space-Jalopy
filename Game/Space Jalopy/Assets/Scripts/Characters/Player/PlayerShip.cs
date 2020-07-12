using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : BaseShip
{
    public ShipPart[] ShipParts;
    public Rigidbody2D rb;
    public PartSteer steer;
    public PartThruster thruster;
    public PartShoot shoot;
    public PartRotate monoprop;
    public HpBar hpbar;


    public override void Start()
    {
        base.Start();
        ShipParts = GetComponentsInChildren<ShipPart>();
        rb = GetComponent<Rigidbody2D>();
        hpbar = FindObjectOfType<HpBar>();
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

    public override void ApplyDamage(int damage)
    {
        base.ApplyDamage(damage);
        hpbar.ModifyHP(currentHp * 1f / startHp * 1f);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Move(Vector2 vector)
    {
        rb.velocity = Vector2.zero;
        base.Move(vector);
    }

    public void AddForce(Vector2 force)
    {
        rb.AddForce(force);
    }

    public void DisablePartsAttack()
    {
        PartBreaker partBreaker = FindObjectOfType<PartBreaker>();
        if (PartsFullyOk())
        {
            partBreaker.DestroyRandomPart();
            partBreaker.DestroyRandomPart();
        }
        else
        {
            partBreaker.DestroyRandomPart();
        }
    }

    public bool PartsFullyOk()
    {
        bool isOkay = true;
        foreach (ShipPart part in ShipParts)
        {
            if (part.partStatus == repairState.isBroken)
            {
                return false;
            }
        }
        return isOkay;
    }
}
