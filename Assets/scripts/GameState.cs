using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    public encounter currEncounter;

    public playerInfo currPlayerInfo;
    private playerCharacter shoppingChar;

    public int currTier;
    public bool testingMode;
    public List<GameObject> savedObjects;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            shoppingChar = GameObject.FindGameObjectWithTag("Player").GetComponent<playerCharacter>();
        }

        //For testing, loads in random stuff
        if(testingMode)
        {
            saveCharacter();
            //currPlayerInfo.displayInfo();

            if(GameObject.FindGameObjectsWithTag("pips") != null)
            {
                foreach(GameObject obj in GameObject.FindGameObjectsWithTag("pips"))
                {
                    obj.GetComponent<levelSquarePips>().initPips();
                }
            }

        }



    }

    private void Awake()
    {
        currPlayerInfo = new playerInfo();

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            currTier = 1;
            currPlayerInfo.health = 10;
            currPlayerInfo.attack = 1;

        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

    }

    private void OnEnable()
    {
        shopTimer.timerFinished += saveCharacter;
    }
    private void OnDisable()
    {
        shopTimer.timerFinished -= saveCharacter;
    }

    public int getCurrTier()
    {

        return currTier;
    }


    //We have an associated class that just stores the current player stats
    void saveCharacter()
    {
        shoppingChar = GameObject.FindGameObjectWithTag("Player").GetComponent<playerCharacter>();
        currPlayerInfo.clone(shoppingChar);
    }

    public void copyPlayerCombat(playerCombatant player)
    {

        player.health = currPlayerInfo.health;
        player.attack = currPlayerInfo.attack;
        player.equippedArmor = currPlayerInfo.currArmor;
        player.equippedWeapon = currPlayerInfo.currWeapon;

    }

    public bool upgradedArmor()
    {

        return currPlayerInfo.currArmor.upgraded;

    }
    public bool upgradedWeapon()
    {

        return currPlayerInfo.currWeapon.upgraded;

    }

}
    