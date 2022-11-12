using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enemyCombatant : combatant
{
    void Start()
    {
        //I will only try to hit the player
        target = GameObject.FindGameObjectWithTag("player").GetComponent<playerCombatant>();
        currentAtkCharge = 0;
        slider = GetComponentInChildren<Slider>();
        particles = GetComponentInChildren<ParticleSystem>();

    }

}
