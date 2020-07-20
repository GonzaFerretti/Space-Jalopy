using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : BaseShip
{
    public ShipPart[] ShipParts;
    public Rigidbody2D rb;
    public PartSteer steer;
    public PartThruster thruster;
    public PartShoot shoot;
    public PartRotate monoprop;
    public HpBar hpbar;
    public PlayerController controller;
    public float originalSpeed;

    public void SetMovementDisable(float time)
    {
        controller.hasDisabledMovement = true;
        StartCoroutine(waitToReEnableMovement(time));
    }

    IEnumerator waitToReEnableMovement(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        controller.hasDisabledMovement = false;
    }

    public void FixAll()
    {
        controller.minigame.Reset();
        steer.Fix();
        thruster.Fix();
        monoprop.Fix();
        shoot.Fix();
    }

    public override void Start()
    {
        base.Start();
        ShipParts = GetComponentsInChildren<ShipPart>();
        rb = GetComponent<Rigidbody2D>();
        hpbar = FindObjectOfType<HpBar>();
        controller = GetComponent<PlayerController>();
        originalSpeed = baseMoveSpeed;
    }
    public override void Attack()
    {
        if (canShoot)
        {
            base.Attack();
            soundM.PlaySFX(SFX.laser);
            if ((shoot.partStatus == repairState.isOk))
            {
                lastProjectile.transform.up = transform.up;
            }
            else
            {
                float angle = Random.Range(-shoot.angle, shoot.angle);
                lastProjectile.transform.up = Utilities.Rotate(transform.up, angle);
            }
        }
    }

    public override void ApplyDamage(int damage)
    {
        if (currentHp - damage <= 0)
        {
            FixAll();
        }
        base.ApplyDamage(damage);
        FindObjectOfType<CameraSreenShake>().ShakeCamera();
        hpbar.ModifyHP(currentHp * 1f / startHp * 1f);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Move(Vector2 vector)
    {
        rb.velocity = Vector2.zero;
        base.Move(vector);
    }

    public void AddForce(Vector2 force)
    {
        rb.AddForce(force);
    }

    public void DisablePartsAttack(bool isChampionAttack)
    {
        PartBreaker partBreaker = FindObjectOfType<PartBreaker>();
        if (PartsFullyOk())
        {
            partBreaker.DestroyRandomPart();
            partBreaker.DestroyRandomPart();
        }
        else
        {
            if (isChampionAttack)
            {
                Switch(partBreaker);
            }
            else { partBreaker.DestroyRandomPart();}
        }
    }

    public void Switch(PartBreaker partBreaker)
    {
        List<int> indices = new List<int>();
        for (int i = 0; i < ShipParts.Length; i++)
        {
            if ((ShipParts[i].partStatus != repairState.isOk))
            {
                indices.Add(i);
            }
        }
        int possibleSwitcheroosAmount = indices.Count;
        int firstIndex = Random.Range(0, indices.Count - 1);
        int secondIndex = -1;
        ShipPart part1 = ShipParts[indices[firstIndex]];
        ShipPart part2 = ShipParts[0];
        if (possibleSwitcheroosAmount > 1)
        {
            while (secondIndex != -1 && secondIndex != firstIndex)
            {
                secondIndex = Random.Range(0, indices.Count - 1);
            }
            if (secondIndex != -1)
            { 
            part2 = ShipParts[indices[secondIndex]];
            }
        }
        partBreaker.DestroyRandomPart();
        partBreaker.DestroyRandomPart();
        part1.Fix();
        if (secondIndex != -1)
        {
            part2.Fix();
        }

        controller.minigame.Reset();
    }

    public bool PartsFullyOk()
    {
        bool isOkay = true;
        foreach (ShipPart part in ShipParts)
        {
            if (part.partStatus == repairState.isBroken)
            {
                return false;
            }
        }
        return isOkay;
    }


    public bool PartsFullyOkAndNotRepairing()
    {
        bool isOkay = true;
        foreach (ShipPart part in ShipParts)
        {
            if (part.partStatus != repairState.isOk)
            {
                return false;
            }
        }
        return isOkay;
    }
}
