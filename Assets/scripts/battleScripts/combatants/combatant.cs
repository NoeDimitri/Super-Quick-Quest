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

    public GameObject floatingText;

    private int poisonDegree;

    private void Start()
    {
        currentAtkCharge = 0;
        slider = GetComponentInChildren<Slider>();
        particles = GetComponentInChildren<ParticleSystem>();

        activeCombat = false;
        updateStats();

        poisonDegree = 0;

    }

    public void addPoison(int amount)
    {
        poisonDegree = Mathf.Max(0, poisonDegree + amount);
    }

    public int getPoison()
    {
        return poisonDegree;
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

    public void spawnText(string textToDisplay, Color textColor)
    {
        GameObject tempText;
        tempText = Instantiate(floatingText, gameObject.transform.position, Quaternion.identity);
        tempText.GetComponentInChildren<TextMesh>().color = textColor;
        tempText.GetComponentInChildren<TextMesh>().text = textToDisplay;

    }

public abstract void takeDamage(int damage);

    public void updateStats()
    {

        healthText.text = health.ToString();
        attackText.text = attack.ToString();

    }

    protected abstract void death();

}
