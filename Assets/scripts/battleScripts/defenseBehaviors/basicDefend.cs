using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicDefend : generalDefend
{

    public override void applyDefense(int amount, combatant defender, combatant attacker)
    {
        int newAmount = Mathf.Max(amount - defender.defense, 0);
        defender.takeDamage(newAmount);

    }
}
