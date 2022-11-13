using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daggerAttack : generalAttack
{
    int prevHealth, baseDamage;
    private void Start()
    {
        attacker = GetComponent<combatant>();
        prevHealth = attacker.health;
        baseDamage = attacker.attack;
    }

    public override void performAttack(combatant target)
    {
        
        if(attacker.health != prevHealth)
        {
            attacker.attack = baseDamage;
            prevHealth = attacker.health;

        }

        target.defendMethod.applyDefense(attacker.attack, attacker);

        attacker.attack += 1;

    }
}

