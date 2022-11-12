using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInfo : MonoBehaviour
{

    public int health;

    public int attack;

    public weapon currWeapon;

    public armor currArmor;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clone(playerCharacter newPlayer)
    {
        health = newPlayer.health;
        attack = newPlayer.attack;
        currWeapon = newPlayer.currentWeapon;
        currArmor = newPlayer.currentArmor;

    }
}
