using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicDefend : generalDefend
{

    public override void applyDefense(int amount, combatant defender, combatant attacker)
    {
        int newAmount = amount - defender.defense;
        defender.takeDamage(newAmount);

    }
}
