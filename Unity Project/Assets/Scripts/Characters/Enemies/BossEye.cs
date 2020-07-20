using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEye : MonoBehaviour
{
    SpriteRenderer sren;
    PlayerShip player;
    void Start()
    {
        sren = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerShip>();
    }

    // Update is called once per frame
    void Update()
    {
        sren.flipX = transform.transform.position.x >= player.transform.position.x;
    }
}
