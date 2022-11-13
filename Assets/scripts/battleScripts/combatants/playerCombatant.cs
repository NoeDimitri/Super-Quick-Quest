using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerCombatant : combatant
{
    public delegate void foesDefeated();
    public static event foesDefeated battleWon;

    public delegate void gameOverFunctions();
    public static event gameOverFunctions gameOver;

    public weapon equippedWeapon;
    public armor equippedArmor;

    public delegate void playerHitFunctions();
    public static event playerHitFunctions playerHit;

    public Animation anim;


    [Header("Enemies")]
    public List<combatant> enemyList;

    public bool enemiesDefeated, battleInitialized = false;

    private void OnEnable()
    {
        battleInitializer.finishedInitialization += populateEnemyList;
        startBattle.finishedStart += startCombat;
    }

    private void OnDisable()
    {
        battleInitializer.finishedInitialization += populateEnemyList;
        startBattle.finishedStart -= startCombat;
    }

    private void startCombat()
    {
        activeCombat = true;
    }

    private void Start()
    {
        enemiesDefeated = false;
        currentAtkCharge = 0;
        slider = GetComponentInChildren<Slider>();
        particles = GetComponentInChildren<ParticleSystem>();
        anim = gameObject.GetComponent<Animation>();

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

        if (activeCombat)
        {
            currentAtkCharge += Time.deltaTime;
            slider.value = Mathf.Min(currentAtkCharge / atkChargeMax, 1);

            if (currentAtkCharge >= atkChargeMax && !enemiesDefeated && battleInitialized)
            {
                target = enemyList[Random.Range(0, enemyList.Count)];

                attackMethod.performAttack(this, target);

                anim.Play("playerAttack");

                currentAtkCharge = 0;

            }
        }

        updateStats();

    }

    protected override void death()
    {
        if(gameOver != null)
        {

            gameOver();

        }
    }

    public void removeEnemy(combatant deadEnemy)
    {
        enemyList.Remove(deadEnemy);

        if (enemyList.Count == 0)
        {
            if (battleWon != null)
            {
                battleWon();
            }

            enemiesDefeated = true;
            Debug.Log("we win!!");
        }
    }

    public override void takeDamage(int damage)
    {
        GameObject damageNums;
        if (damage <= 0)
        {
            damageNums = Instantiate(floatingText, transform.position, Quaternion.identity);
            damageNums.GetComponentInChildren<TextMesh>().color = Color.blue;
            damageNums.GetComponentInChildren<TextMesh>().text = "blocked!";
            return;

        }

        health -= damage;
        particles.Play();

        damageNums = Instantiate(floatingText, transform.position, Quaternion.identity);
        damageNums.GetComponentInChildren<TextMesh>().text = "-" + damage;

        if (playerHit != null)
        {
            playerHit();
        }

        if (health <= 0)
        {
            death();
        }
        

        updateStats();

    }
}
