using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dualdaggers : generalAttack
{


    public int atkGainInc, upgradedAtkInc;

    [SerializeField]
    private int tempAtkGain;

    public float atkSpeedMultiplier;

    private playerCombatant player;


    private void OnEnable()
    {
        playerCombatant.playerHit += resetAtkInc;
    }

    private void OnDisable()
    {
        playerCombatant.playerHit -= resetAtkInc;

    }

    private void resetAtkInc()
    {
        //reset attack and reset attack speed
        player.attack -= tempAtkGain;
        player.atkChargeMax = GameState.Instance.currPlayerInfo.currWeapon.attackSpeedGaugeMax;
        tempAtkGain = 0;



    }
    public void Start()
    {
        tempAtkGain = 0;
        if (GameObject.FindGameObjectWithTag("player") != null)
        {
            player = GameObject.FindGameObjectWithTag("player").GetComponent<playerCombatant>();

        }
    }

    public override void performAttack(combatant attacker, combatant target)
    {

        int newAttackDamage = Mathf.CeilToInt(attacker.attack * GameState.Instance.returnWeaponAtkMultiplier());

        if (!GameState.Instance.upgradedWeapon())
        {
            tempAtkGain += atkGainInc;
            player.attack += atkGainInc;
        }
        else
        {
            tempAtkGain += upgradedAtkInc;
            player.attack += upgradedAtkInc;
            player.atkChargeMax *= atkSpeedMultiplier;

        }

        target.defendMethod.applyDefense(newAttackDamage, target, attacker);

    }
}
