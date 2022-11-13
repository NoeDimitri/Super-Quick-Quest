using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleInitializer : MonoBehaviour
{

    public GameState currentGameState;
    //Related to 
    public GameObject enemyPrefab;
    public Transform enemyFolder;

    private playerCombatant currentPlayer;

    public List<Transform> spawnLocations;

    public delegate void battleInitialized();
    public static event battleInitialized finishedInitialization;

    void Start()
    {
        foreach (GameObject pos in GameObject.FindGameObjectsWithTag("spawnLocation"))
        {
            spawnLocations.Add(pos.GetComponent<Transform>());
        }


        currentPlayer = GameObject.FindGameObjectWithTag("player").GetComponent<playerCombatant>();

        //Duplicates over player stats
        copyPlayerStats();

        int i = 0;

        foreach(monsterInfo monInfo in currentGameState.currEncounter.monsters)
        {

            createEnemy(monInfo, spawnLocations[i++]);
            

        }

        //Signal that we are done intitializing the enemies
        if (finishedInitialization != null)
        {

            finishedInitialization();

        }

    }

    void copyPlayerStats()
    {
        currentPlayer.health = GameState.Instance.currPlayerInfo.health;
        currentPlayer.attack = GameState.Instance.currPlayerInfo.attack;
        currentPlayer.equippedArmor = GameState.Instance.currPlayerInfo.currArmor;
        currentPlayer.equippedWeapon = GameState.Instance.currPlayerInfo.currWeapon;
    }

    void createEnemy(monsterInfo enemy, Transform pos)
    {
        GameObject tempEnemyPrefab;
        enemyCombatant tempEnemy;

        //Create new enemy
        tempEnemyPrefab = Instantiate(enemyPrefab, pos.position, Quaternion.identity, enemyFolder);

        tempEnemy = tempEnemyPrefab.GetComponent<enemyCombatant>();


        tempEnemyPrefab.transform.position = pos.position;
        tempEnemyPrefab.GetComponent<SpriteRenderer>().sprite = enemy.monsterSprite;

        tempEnemy.health = enemy.health;
        tempEnemy.attack = enemy.attack;
        tempEnemy.atkChargeMax = enemy.atkChargeMax;
        tempEnemy.defense = enemy.defense;
        tempEnemy.attackMethod = enemy.attackMethod;
        tempEnemy.defendMethod = enemy.defendMethod;

        tempEnemy.target = GameObject.FindGameObjectWithTag("player").GetComponent<playerCombatant>();
    }

}
