using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class generalAttack : MonoBehaviour
{
    public abstract void performAttack(combatant attacker, combatant target);

}
