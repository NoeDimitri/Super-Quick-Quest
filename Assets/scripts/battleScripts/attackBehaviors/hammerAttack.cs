using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerAttack : generalAttack
{
    public float knockback;
    public int defDecrease, defDecreaseUpgraded;

    public GameObject floatingText;
    public override void performAttack(combatant attacker, combatant target)
    {
        int newAmount = Mathf.CeilToInt(attacker.attack * GameState.Instance.returnWeaponAtkMultiplier());

        target.defendMethod.applyDefense(newAmount, target, attacker);

        if (GameState.Instance.upgradedWeapon())
        {

            target.currentAtkCharge = Mathf.Max(target.currentAtkCharge - knockback, 0);
            target.defense -= defDecreaseUpgraded;

        }
        else
        {
            target.defense -= defDecrease;

        }

    }
}
