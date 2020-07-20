using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionShip : PidgeonShip
{
    PlayerShip player;
    public override void Start()
    {
        base.Start();
        player = FindObjectOfType<PlayerShip>();
        usualBaseSpeed = baseMoveSpeed;
    }
    public override void CheckProjectileTimer()
    {
        base.CheckProjectileTimer();
        if (projectileTimer > projectileTime && isStopped)
        {
            anim.SetBool("open", false);
            anim.SetBool("isAttacking", false);
            baseMoveSpeed = usualBaseSpeed;
            isStopped = false;
        }

    }

    public override void Attack()
    {
        base.Attack();
        if (!(this is BossShip))
        {
            lastProjectile.GetComponent<ChampionProjectile>().ship = player;
        }
    }
}
