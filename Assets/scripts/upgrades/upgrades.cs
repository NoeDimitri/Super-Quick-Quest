using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrades : MonoBehaviour
{
    [Header("Info")]
    public string upgradeName;
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
    public int itemExperience;

}
