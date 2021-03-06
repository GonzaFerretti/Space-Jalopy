﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PidgeonProjectile : BaseProjectile
{
    public override void Init(BaseShip firingShip)
    {
        base.Init(firingShip);
        FindObjectOfType<EnemySpawner>().UpdateDeadEnemy(firingShip.gameObject);
        Destroy(firingShip.gameObject);
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {
            collision.GetComponent<PlayerShip>().DisablePartsAttack(false);
        }
        base.OnTriggerEnter2D(collision);
    }
}
