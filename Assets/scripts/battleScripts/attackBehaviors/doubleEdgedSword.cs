using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleEdgedSword : generalAttack
{

    public float damageMultiplier;
    public float selfDamagePercent;

    public override void performAttack(combatant attacker, combatant target)
    {

        int newAttackDamage = Mathf.CeilToInt(attacker.attack * damageMultiplier);

        if(!GameState.Instance.upgradedWeapon())
        {

            attacker.takeDamage(Mathf.CeilToInt(attacker.attack * selfDamagePercent));

        }
        else
        {
            //so we don't overHeal
            int selfHeal = Mathf.Min(Mathf.CeilToInt(attacker.attack * selfDamagePercent) + attacker.health, GameState.Instance.currPlayerInfo.health);

            //display new healing
            int dif = selfHeal - attacker.health;
            if (selfHeal != 0)
            {
                attacker.spawnText("+" + dif, Color.green);
            }

            attacker.health = selfHeal;

        }


        target.defendMethod.applyDefense(newAttackDamage, target, attacker);

    }

}
