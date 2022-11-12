using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : equipment
{
    public float damageMultiplier;
    public float atkSpeedMultiplier;
    private void Start()
    {
        ColorUtility.TryParseHtmlString("#FF6347", out associatedColor);
    }


    //Copies over weapon info
    public void clone(weapon newWeapon)
    {
        //Default stats
        upgradeName = newWeapon.upgradeName;
        upgradeDescription = newWeapon.upgradeDescription;
        upgradeSprite = newWeapon.upgradeSprite;
        associatedColor = newWeapon.associatedColor;
        damageMultiplier = newWeapon.damageMultiplier;
        atkSpeedMultiplier = newWeapon.atkSpeedMultiplier;

        itemExperience = 1;

        upgraded = false;

    }


}
