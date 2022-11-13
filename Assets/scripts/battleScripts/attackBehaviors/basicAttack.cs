using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicAttack : generalAttack
{
    public override void performAttack(combatant attacker, combatant target)
    {

        target.defendMethod.applyDefense(attacker.attack, target, attacker);

    }
}
