using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float remainingTime;
    public void Update()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime <0)
        {
            Destroy(gameObject);
        }
    }
}
