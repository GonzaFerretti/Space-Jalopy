using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicEnemyShip : BaseShip
{
    public bool hasBeenStopped;
    public bool isStationary;
    public bool isGoingRight;

    public override void Start()
    {
        base.Start();
        anim.SetBool("isStationary", isStationary);
    }
    public override void Update()
    {
        base.Update();
        if (!hasBeenStopped)
        {
            Move(Vector2.zero);
        }
        else
        {
            isGoingRight = !isGoingRight;
            hasBeenStopped = false;
            Move(Vector2.zero);
        }
        CheckProjectileTimer();
        if (canShoot)
        {
            Attack();
            if (!(this is BossShip))
            { 
            lastProjectile.transform.up = transform.up;
            }
        }
    }

    public override void Move(Vector2 vector)
    {
        float directionMult = (isGoingRight) ? 1 : -1;
        sren.flipX = (isGoingRight);
        Vector2 forceToMove = Vector2.right * directionMult * baseMoveSpeed * Time.deltaTime;
        base.Move(forceToMove);
    }
}
