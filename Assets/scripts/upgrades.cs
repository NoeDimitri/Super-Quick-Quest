using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrades : MonoBehaviour
{
    [Header("Info")]
    public string upgradeName;
    public string upgradeDescription;

}

public class buff : upgrades
{




}

public class equipment : upgrades
{
    [Header("Equiptment Info")]
    public string itemName;
    public string itemDescription;
    int experience;

}

public class weapons : equipment
{
    float damageModifer;


}

public class armor : equipment
{

    float defense;


}