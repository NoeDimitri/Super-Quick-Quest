using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopScript : MonoBehaviour
{
    public shopListing[] shopListings;


    [Header("Upgrades")]
    public GameObject weaponHolder;
    public GameObject buffHolder;
    public GameObject armorHolder;

    public int equipChance;

    public weapon[] allWeapons;
    //public buff[] allBuffs;
    public armor[] allArmors;

    //Initialize the lists
    private void Start()
    {
        shopListings = GetComponentsInChildren<shopListing>();
        allWeapons = weaponHolder.GetComponentsInChildren<weapon>();
        allArmors = armorHolder.GetComponentsInChildren<armor>();

        rerollShop();

    }


    //Reroll the shop :))
    public void rerollShop()
    {
        //reroll items in shop
        foreach(shopListing shop in shopListings)
        {
            shop.shopType = decideType();
            shop.currentArmor = allArmors[Random.Range(0, allArmors.Length)];
            shop.currentWeapon = allWeapons[Random.Range(0, allWeapons.Length)];
            shop.currentBuff.generateRandomBuff();
            shop.displayInfo();
        }


    }

    shopListing.listingType decideType()
    {

        //Decide if we are an equipment
        if (Random.Range(0, 100) <= equipChance)
        {
            //50% chance to get one or the other
            if(Random.Range(0, 2) == 1)
            {
                return shopListing.listingType.armor;
            }
            return shopListing.listingType.weapon;

        }

        return shopListing.listingType.buff;

    }


}
