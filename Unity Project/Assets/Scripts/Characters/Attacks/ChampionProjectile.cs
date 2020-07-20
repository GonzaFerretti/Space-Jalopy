using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionProjectile : BaseProjectile
{
    public PlayerShip ship;
    public float nudgeSpeed;
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {
            collision.GetComponent<PlayerShip>().DisablePartsAttack(true);
        }
        base.OnTriggerEnter2D(collision);
    }

    public override void Move()
    {
        base.Move();
        float directionMultiplier = (transform.position.x > ship.transform.position.x) ? -1 : 1;
        Vector2 forceToAdd = Vector2.right * nudgeSpeed * Time.deltaTime * directionMultiplier;
        transform.position += new Vector3(forceToAdd.x,forceToAdd.y,0);
    }
}
