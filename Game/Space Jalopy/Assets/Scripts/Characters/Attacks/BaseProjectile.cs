using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    public float speed;
    public string targetTag;
    public int damage;


    public void Init(BaseShip firingShip)
    {
        speed = firingShip.basicProjectileSpeed;
    }

    public void Move()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("toque algo");
        if (collision.tag == targetTag)
        {
            Debug.Log("impacté a " + collision.name);
            collision.GetComponent<BaseShip>().ApplyDamage(damage);
            Destroy(gameObject);
        }
    }
}
