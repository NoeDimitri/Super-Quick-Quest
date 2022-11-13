using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armor : equipment
{
    public int def;
    public generalDefend defenseMethod;

    private void Start()
    {
        defenseMethod = GetComponent<generalDefend>();
        ColorUtility.TryParseHtmlString("#1E90FF", out associatedColor);
    }
    public void clone(armor newArmor)
    {
        //Default stats
        upgradeName = newArmor.upgradeName;
        upgradeDescription = newArmor.upgradeDescription;
        upgradeSprite = newArmor.upgradeSprite;
        associatedColor = newArmor.associatedColor;
        itemExperience = 1;
        upgraded = false;

    }

}
