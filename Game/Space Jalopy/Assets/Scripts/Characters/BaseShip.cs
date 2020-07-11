using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShip : MonoBehaviour
{
    public int startHp;
    public int currentHp;
    public GameObject attackSpawnPoint;
    public GameObject projectile;
    public GameObject lastProjectile;
    public float baseMoveSpeed;
    public void ApplyDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp<=0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void Start()
    {
        currentHp = startHp;
    }

    public virtual void Attack()
    {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.position = attackSpawnPoint.transform.position;
        newProjectile.GetComponent<BaseProjectile>().Init(this);
        lastProjectile = newProjectile;
    }
}
