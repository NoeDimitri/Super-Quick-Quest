using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostDefense : generalDefend
{
    bool hasBeenHit = false;

    public override void applyDefense(int amount, combatant defender, combatant attacker)
    {
        int newAmount;

        if (!hasBeenHit)
        {
            hasBeenHit = true;
            newAmount = 0;
        }
        else
        {
            newAmount = Mathf.Max(amount - defender.defense, 0);
        }

        defender.takeDamage(newAmount);


    }


}
