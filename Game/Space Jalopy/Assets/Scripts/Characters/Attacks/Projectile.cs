using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseProjectile : MonoBehaviour
{
    public float speed;
    public abstract void Init(BaseShip firingShip);
    public abstract void Move();

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public virtual void Update()
    {
        Move();
    }
}
