using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class combatant : MonoBehaviour
{

    public bool activeCombat;

    [Header("Stats")]
    public int health;
    public int attack;
    public float atkChargeMax;
    public int defense;

    public float currentAtkCharge;

    protected Slider slider;
    public ParticleSystem particles;

    [Header("Attacking/Defending")]
    public generalAttack attackMethod;
    public generalDefend defendMethod;
    public combatant target;

    [Header("Stat Display")]
    public TMP_Text healthText;
    public TMP_Text attackText;


    private void Start()
    {
        currentAtkCharge = 0;
        slider = GetComponentInChildren<Slider>();
        particles = GetComponentInChildren<ParticleSystem>();

        activeCombat = false;
        updateStats();

    }

    private void Update()
    {

        if (activeCombat)
        {
            currentAtkCharge += Time.deltaTime;
            slider.value = Mathf.Min(currentAtkCharge / atkChargeMax, 1);
            if (currentAtkCharge >= atkChargeMax)
            {

                attackMethod.performAttack(this, target);

                currentAtkCharge = 0;

            }

            updateStats();
        }

    }

    private void startCombat()
    {
        activeCombat = true;
    }

    private void OnEnable()
    {
        startBattle.finishedStart += startCombat;
    }

    private void OnDisable()
    {
        startBattle.finishedStart -= startCombat;
    }

    public abstract void takeDamage(int damage);

    public void updateStats()
    {
        healthText.text = health.ToString();
        attackText.text = attack.ToString();

    }

    protected abstract void death();

}
