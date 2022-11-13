using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thornsArmor : generalDefend
{
    public float reflect, upgradedReflect;
    public override void applyDefense(int amount, combatant defender, combatant attacker)
    {
        float finalReflect;

        if(GameState.Instance.upgradedArmor())
        {

            finalReflect = upgradedReflect;
        }
        else
        {
            finalReflect = reflect;
        }

        int damageReflected = Mathf.CeilToInt(finalReflect * amount);

        attacker.takeDamage(damageReflected);


        Mathf.Ceil(amount);

        int newAmount = Mathf.Max(amount - defender.defense, 0);
        defender.takeDamage(newAmount);

    }
}
