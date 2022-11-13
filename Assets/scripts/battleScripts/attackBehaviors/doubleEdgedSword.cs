using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleEdgedSword : generalAttack
{

    public float selfDamagePercent;

    public override void performAttack(combatant attacker, combatant target)
    {

/*        GameState.Instance.currPlayerInfo.currWeapon.getLevel();
*/
        int newAttackDamage = attacker.attack * 5;

        Debug.Log(attacker.attack * selfDamagePercent);

        attacker.takeDamage(Mathf.CeilToInt(attacker.attack * selfDamagePercent));

        target.defendMethod.applyDefense(newAttackDamage, target, attacker);

    }

}
