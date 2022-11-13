using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightHelmet : generalDefend
{
    public int standardDef, upgradedDef;
    public override void applyDefense(int amount, combatant defender, combatant attacker)
    {
        int finalDef;

        if(GameState.Instance.upgradedArmor())
        {
            finalDef = upgradedDef;
        }
        else
        {
            finalDef = standardDef;
        }


        int newAmount = Mathf.Max(amount - finalDef, 0);
        defender.takeDamage(newAmount);

    }
}
