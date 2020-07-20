using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShip : ChampionShip
{
    public override void ApplyDamage(int damage)
    {
        if (currentHp - damage <= 0)
        {
            try
            {
                foreach (HookProjectile hook in FindObjectsOfType<HookProjectile>())
                {
                    Destroy(hook.gameObject);
                }
            }
            catch
            {

            }
        }
        base.ApplyDamage(damage);

    }
}
