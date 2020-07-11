using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerShip ship;
    public bool isRepairing = false;
    public void Start()
    {
        ship = GetComponent<PlayerShip>();
    }

    public void Update()
    {
        CheckSteer();
        CheckThruster();
        if (!isRepairing)
        { 
            CheckShoot();
            CheckRepair();
        }
    }

    public void CheckSteer()
    {
        if (Input.GetAxis("Horizontal")!= 0)
        {
            Vector2 finalForce = Vector2.right * ship.baseMoveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
            ship.transform.position += new Vector3(finalForce.x, finalForce.y);
        }
    }

    public void CheckThruster()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            Vector2 finalForce = Vector2.up * ship.baseMoveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
            ship.transform.position += new Vector3(finalForce.x,finalForce.y);
        }
    }

    public void CheckShoot()
    {
        if (Input.GetButton("Fire1"))
        {
            ship.Attack();
        }
    }

    public void CheckRepair()
    {
        for (int i = 49; i <= 53; i++)
        {
            if (Input.GetKey((KeyCode)i))
            {
                ship.ShipParts[i - 49].Fix();
                //isRepairing = true;
                break;
            }
        }
    }
}
