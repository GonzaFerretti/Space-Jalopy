using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    public float speed;
    public string targetTag;
    public int damage;


    public virtual void Init(BaseShip firingShip)
    {
        speed = firingShip.basicProjectileSpeed;
    }

    public virtual void Move()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void Update()
    {
        Move();
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {
            collision.GetComponent<BaseShip>().ApplyDamage(damage);
            Destroy(gameObject);
        }
    }
}
