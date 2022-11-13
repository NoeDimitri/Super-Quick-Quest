using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class generalDefend : MonoBehaviour
{

    private void Start()
    {

    }

    public abstract void applyDefense(int amount, combatant defender, combatant attacker);
    
}
