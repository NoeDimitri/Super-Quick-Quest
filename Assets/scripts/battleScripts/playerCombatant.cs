using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerCombatant : combatant
{
    public weapon equippedWeapon;
    public armor equippedArmor;

    [Header("Enemies")]
    public GameObject enemyContainer;
    public List<combatant> enemyList;

    public bool enemiesDefeated;


    private void Start()
    {
        enemiesDefeated = false;
        currentAtkCharge = 0;
        slider = GetComponentInChildren<Slider>();
        particles = GetComponentInChildren<ParticleSystem>();

        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
        {
            enemyList.Add(enemy.GetComponent<combatant>());
        }

    }
    private void Update()
    {

        currentAtkCharge += Time.deltaTime;
        slider.value = Mathf.Min(currentAtkCharge / atkChargeMax, 1);

        if (currentAtkCharge >= atkChargeMax && !enemiesDefeated)
        {
            target = enemyList[Random.Range(0, enemyList.Count)];

            attackMethod.performAttack(target);

            currentAtkCharge = 0;

        }

        updateStats();

    }

    protected override void death()
    {
        Debug.Log("player has died");
    }

    public void removeEnemy(combatant deadEnemy)
    {
        enemyList.Remove(deadEnemy);

        if (enemyList.Count == 0)
        {
            enemiesDefeated = true;
            Debug.Log("we win!!");
        }
    }

}
