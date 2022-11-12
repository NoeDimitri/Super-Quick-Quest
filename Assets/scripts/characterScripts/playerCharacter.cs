using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public enum stats {hp, atk, spd, def };

    [Header("Player Stats")]
    public int health;
    public int attack;
    public int defense;
    public float speed;

    [Header("Equipment")]
    public weapon currentWeapon;
    public armor currentArmor;

    [Header("Info Refs")]
    public TMP_Text healthText;
    public TMP_Text atkText;
    public TMP_Text spdText;

    public TMP_Text weaponText;
    public TMP_Text armorText;
    public SpriteRenderer weaponImage;
    public SpriteRenderer armorImage;

    public levelPips weaponPip;
    public levelPips armorPip;

    void Start()
    {
        Color weaponColor, armorColor;
        ColorUtility.TryParseHtmlString("#FF6347", out weaponColor);
        ColorUtility.TryParseHtmlString("#1E90FF", out armorColor);

        weaponText.color = weaponColor;
        armorText.color = armorColor;

        currentWeapon = GetComponentInChildren<weapon>();
        currentArmor = GetComponentInChildren<armor>();

        refreshStats();
    }

    public void refreshStats()
    {

        healthText.text = "Health: " + health;
        atkText.text = "Attack: " + attack;
        spdText.text = "Speed: " + speed;

        weaponText.text = currentWeapon.upgradeName;
        weaponImage.sprite = currentWeapon.upgradeSprite;
        armorText.text = currentArmor.upgradeName;
        //armorImage.sprite = currentArmor.upgradeSprite;


    }

    public void equipWeapon(weapon newWeapon)
    {

        if(currentWeapon.upgradeName == newWeapon.upgradeName)
        {

            currentWeapon.increaseLevel();
            weaponPip.updatePips(currentWeapon.getLevel());

        }

        else
        {

            currentWeapon.clone(newWeapon);
            weaponPip.updatePips(currentWeapon.getLevel());

        }

        refreshStats();
    }

    public void equipArmor(armor newArmor)
    {

        if (currentArmor.upgradeName == newArmor.upgradeName)
        {
            //upgrade current item
            currentArmor.increaseLevel();
            armorPip.updatePips(currentArmor.getLevel());

        }

        else
        {
            //Copy over armor
            currentArmor.clone(newArmor);
            armorPip.updatePips(currentArmor.getLevel());

        }

        refreshStats();
    }

}


