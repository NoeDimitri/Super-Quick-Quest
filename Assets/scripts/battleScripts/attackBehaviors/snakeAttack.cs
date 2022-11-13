using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeAttack : generalAttack
{
    public override void performAttack(combatant attacker, combatant target)
    {

        target.defendMethod.applyDefense(attacker.attack, target, attacker);

        target.addPoison(1);
    }
}
