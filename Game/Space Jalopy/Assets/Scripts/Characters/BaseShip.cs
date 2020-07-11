using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShip : MonoBehaviour
{
    public int startHp;
    public int currentHp;
    public Animator anim;
    public GameObject attackSpawnPoint;
    public GameObject projectile;
    public GameObject lastProjectile;
    public float baseMoveSpeed;
    public SpriteRenderer sren;

    public float projectileTimer;
    public float projectileTime;
    public bool canShoot = true;

    public void ApplyDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp<=0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void Update()
    {
        CheckProjectileTimer();
    }

    public virtual void Start()
    {
        currentHp = startHp;
        anim = GetComponent<Animator>();
        sren = GetComponent<SpriteRenderer>();
    }

    void CheckProjectileTimer()
    {
        if (!canShoot && projectileTimer < projectileTime)
        {
            projectileTimer += Time.deltaTime;
        }
        else
        {
            canShoot = true;
            projectileTimer = 0;
        }
    }

    public virtual void Attack()
    {
        if (canShoot)
        {
            SpawnBullet();
            canShoot = false;
        }
    }

    public void SpawnBullet()
    {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.position = attackSpawnPoint.transform.position;
        newProjectile.GetComponent<BaseProjectile>().Init(this);
        lastProjectile = newProjectile;
    }
}
