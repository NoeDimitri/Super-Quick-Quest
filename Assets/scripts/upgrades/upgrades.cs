using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrades : MonoBehaviour
{
    [Header("Info")]
    public string penalty;
    public string upgradeName;

    [TextArea(8, 15)]
    public string upgradeDescription;
    public Sprite upgradeSprite;
    protected Color associatedColor;


    public Color returnUpgradeColor()
    {
        return associatedColor;
    }

}

public class equipment : upgrades
{
    public int itemExperience = 1;

    //if it's been fully upgraded
    public bool upgraded = false;

    public void increaseLevel()
    {
        itemExperience++;
        if(itemExperience >= 3)
        {
            upgraded = true;
            Debug.Log("Fully leveled");
        }
    }

    public int getLevel()
    {
        return itemExperience;
    }

}
