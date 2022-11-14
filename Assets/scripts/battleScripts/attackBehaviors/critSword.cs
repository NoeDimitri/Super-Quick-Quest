using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class critSword : generalAttack
{
    public float critChance, critChanceEmpowered, critMultiplier, critMultiplierEmpowered;
    public GameObject floatingText;
    public override void performAttack(combatant attacker, combatant target)
    {
        float finalCritChance;
        float finalCritMultiplier;

        if (GameState.Instance.upgradedWeapon())
        {
            finalCritChance = critChanceEmpowered;
            finalCritMultiplier = critMultiplierEmpowered;

        }
        else
        {
            finalCritChance = critChance;
            finalCritMultiplier = critMultiplier;
        }

        int newAmount = attacker.attack;

        //We crit!
        if (Random.Range(0, 100) < finalCritChance)
        {
            newAmount = (int)(attacker.attack * finalCritMultiplier);

            floatingText = Instantiate(floatingText, target.gameObject.transform.position, Quaternion.identity);
            floatingText.GetComponentInChildren<TextMesh>().color = Color.blue;
            floatingText.GetComponentInChildren<TextMesh>().text = "crit!";
        }

        target.defendMethod.applyDefense(newAmount, target, attacker);

    }
}
