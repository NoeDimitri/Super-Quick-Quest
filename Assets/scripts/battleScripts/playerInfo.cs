using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInfo
{

    public int health;
    public int attack;
    public weapon currWeapon;
    public armor currArmor;

    public void clone(playerCharacter newPlayer)
    {
        health = newPlayer.health;
        attack = newPlayer.attack;
        currWeapon = newPlayer.currentWeapon;
        currArmor = newPlayer.currentArmor;

    }

    public void displayInfo()
    {
        Debug.Log("health: " + health);
        Debug.Log("attack: " + attack);
        Debug.Log("currWeapon: " + currWeapon);
        Debug.Log("currArmor: " + currArmor);


    }
}
