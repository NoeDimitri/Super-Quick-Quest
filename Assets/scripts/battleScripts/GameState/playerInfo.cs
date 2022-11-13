using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInfo
{

    public int health;
    public int attack;
    public weapon currWeapon;
    public armor currArmor;

    playerInfo()
    {



    }

    public void copyInfo(playerCharacter newPlayer)
    {
        health = newPlayer.health;
        attack = newPlayer.attack;
        currWeapon = newPlayer.currentWeapon;
        currArmor = newPlayer.currentArmor;

    }
}
