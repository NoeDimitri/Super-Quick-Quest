using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicDefend : generalDefend
{

    public override void applyDefense(int amount, combatant attacker)
    {
        int newAmount = amount - defender.defense;
        defender.takeDamage(newAmount);

    }
}
