using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerCombatant : combatant
{
    public weapon equippedWeapon;
    public armor equippedArmor;

    [Header("Enemies")]
    public List<combatant> enemyList;

    public bool enemiesDefeated, battleInitialized = false;

    private void OnEnable()
    {
        battleInitializer.finishedInitialization += populateEnemyList;
    }

    private void OnDisable()
    {
        battleInitializer.finishedInitialization += populateEnemyList;
    }
    private void Start()
    {
        enemiesDefeated = false;
        currentAtkCharge = 0;
        slider = GetComponentInChildren<Slider>();
        particles = GetComponentInChildren<ParticleSystem>();

    }

    private void populateEnemyList()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
        {
            enemyList.Add(enemy.GetComponent<combatant>());
        }

        battleInitialized = true;

    }
    private void Update()
    {

        currentAtkCharge += Time.deltaTime;
        slider.value = Mathf.Min(currentAtkCharge / atkChargeMax, 1);

        if (currentAtkCharge >= atkChargeMax && !enemiesDefeated && battleInitialized)
        {
            target = enemyList[Random.Range(0, enemyList.Count)];

            attackMethod.performAttack(this, target);

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
