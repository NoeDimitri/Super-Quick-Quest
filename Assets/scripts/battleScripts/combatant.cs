using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatant : MonoBehaviour
{
    [Header("Stats")]
    public int health;
    public int attack;
    public float atkSpeedGaugeMax;
    public float defense;

    [Header("Temp Modifiers")]
    public float healthModifier;
    public float attackModifier;
    public float speedModifier;
    public float defenseModifier;



}
