using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beserkersHelm : generalDefend
{
    public int defaultAtkGain, upgradedAtkGain;
    public playerCombatant player;
    private void OnEnable()
    {
        playerCombatant.playerHit += boostDamage;
    }

    private void OnDisable()
    {
        playerCombatant.playerHit -= boostDamage;

    }

    private void boostDamage()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<playerCombatant>();

        if (GameState.Instance.upgradedArmor())
        {
            player.attack += upgradedAtkGain;
        }
        else
        {
            player.attack += defaultAtkGain;
        }

    }
    public void Start()
    {
        if(GameObject.FindGameObjectWithTag("player") != null)
        {
            player = GameObject.FindGameObjectWithTag("player").GetComponent<playerCombatant>();

        }
    }

    public override void applyDefense(int amount, combatant defender, combatant attacker)
    {

        int newAmount = Mathf.Max(amount - defender.defense, 0);
        defender.takeDamage(newAmount);

    }
}
