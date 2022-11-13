using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public encounter currEncounter;

    public playerInfo currPlayerInfo;
    private playerCharacter shoppingChar;

    public int currTier;

    // Start is called before the first frame update
    void Start()
    {


        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            shoppingChar = GameObject.FindGameObjectWithTag("Player").GetComponent<playerCharacter>();
        }


        //For testing
        saveCharacter();

        //if instance is null;
        currTier = 1;
    }

    private void Awake()
    {
        currPlayerInfo = new playerInfo();
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
        currPlayerInfo.clone(shoppingChar);
    }

    public void copyPlayerCombat(playerCombatant player)
    {

        player.health = currPlayerInfo.health;
        player.attack = currPlayerInfo.attack;
        player.equippedArmor = currPlayerInfo.currArmor;
        player.equippedWeapon = currPlayerInfo.currWeapon;

    }


}
    