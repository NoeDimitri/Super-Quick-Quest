using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ninjaMask : generalDefend
{

    public GameObject damageText;
    public int dodgeChance;
    public int dodgeChanceUpgraded;


    public override void applyDefense(int amount, combatant defender, combatant attacker)
    {
        int currentDodgeChance;
        if(GameState.Instance.currPlayerInfo.currArmor.upgraded)
        {
            currentDodgeChance = dodgeChance;
        }
        else
        {
            currentDodgeChance = dodgeChanceUpgraded;
        }

        if(Random.Range(0, 100) < currentDodgeChance)
        {
            GameObject damageNums = Instantiate(damageText, defender.transform.position, Quaternion.identity);
            damageNums.GetComponentInChildren<TextMesh>().color = Color.blue;
            damageNums.GetComponentInChildren<TextMesh>().text = "Dodged!";
            return;
        }

        int newAmount = Mathf.Max(amount - defender.defense, 0);
        defender.takeDamage(newAmount);

    }
}
