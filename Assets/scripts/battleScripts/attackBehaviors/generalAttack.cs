using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class generalAttack : MonoBehaviour
{
    public combatant attacker;

    private void Start()
    {
        attacker = GetComponent<combatant>();
    }

    public abstract void performAttack(combatant target);

}
