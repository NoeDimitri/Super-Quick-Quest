using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enemyCombatant : combatant
{
    //so i can remove stuff properly
    playerCombatant playerObj;
    void Start()
    {
        //I will only try to hit the player
        playerObj = GameObject.FindGameObjectWithTag("player").GetComponent<playerCombatant>();
        target = playerObj;
        currentAtkCharge = Random.Range(0f, 0.5f);
        slider = GetComponentInChildren<Slider>();
        particles = GetComponentInChildren<ParticleSystem>();

    }

    protected override void death()
    {
        playerObj.removeEnemy(this);

        Destroy(gameObject);

    }


}
