using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerShip ship;
    public RepairMinigame minigame;
    public bool isRepairing = false;
    public void Start()
    {
        ship = GetComponent<PlayerShip>();
    }

    public void Update()
    {
        CheckMovement();
        if (!isRepairing)
        {
            CheckShoot();
            CheckRepair();
        }
        else
        {
            CheckMinigameArrows();
        }
    }

    public void CheckMinigameArrows()
    {
        if(minigame.currentDirections[0].Check())
        {
            if (minigame.RemoveCurrentArrow())
            {
                isRepairing = false;
                minigame.part.Fix();
            }
        }
    }

    public void CheckSteer()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            Vector2 finalForce = Vector2.right * ship.baseMoveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
            ship.Move(finalForce);
        }
    }

    public void CheckMovement()
    {
        bool isMovingVertical = Input.GetAxis("Vertical") != 0;
        bool isMovingHorizontal = Input.GetAxis("Horizontal") != 0;
        if (isMovingHorizontal || isMovingVertical)
        {
            float lengthLimit = ship.baseMoveSpeed* Time.deltaTime;
            Vector2 finalForce = Vector2.right * ship.baseMoveSpeed * Time.deltaTime * Input.GetAxis("Horizontal") + Vector2.up * ship.baseMoveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
            finalForce = Vector2.ClampMagnitude(finalForce, lengthLimit);
            ship.Move(finalForce);
        }
    }

    public void CheckThruster()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            Vector2 finalForce = Vector2.up * ship.baseMoveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
            ship.Move(finalForce);
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
                if (ship.ShipParts[i - 49].partStatus == repairState.isBroken)
                { 
                    ship.ShipParts[i - 49].StartFix();
                    minigame.Init(ship.ShipParts[i - 49], 3);
                    isRepairing = true;
                    break;
                }
            }
        }
    }
}
