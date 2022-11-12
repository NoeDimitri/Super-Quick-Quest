using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class generalDefend : MonoBehaviour
{
    public combatant defender;
    private void Start()
    {
        defender = GetComponent<combatant>();

    }

    public abstract void applyDefense(int amount, combatant attacker);
    
}
