using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class critterMask : generalDefend
{
    public float critChance, critChanceEmpowered, critMultiplier, critMultiplierEmpowered;

    public override void applyDefense(int amount, combatant defender, combatant attacker)
    {
        float finalCritChance;
        float finalCritMultiplier;

        if (GameState.Instance.upgradedArmor())
        {
            finalCritChance = critChanceEmpowered;
            finalCritMultiplier = critMultiplierEmpowered;

        }
        else
        {
            finalCritChance = critChance;
            finalCritMultiplier = critMultiplier;
        }

        int newAmount = amount;

        if (Random.Range(0, 100) < finalCritChance)
        {
            newAmount = (int)(amount * finalCritMultiplier);
        }

        defender.takeDamage(newAmount);

    }
}
