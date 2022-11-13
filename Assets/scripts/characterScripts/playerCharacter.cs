using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class playerCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public enum stats {hp, atk};

    [Header("Player Stats")]
    public int health;
    public int attack;

    public int maxHealth;
    public int maxAttack;
    
    [Header("Equipment")]
    public weapon currentWeapon;
    public armor currentArmor;

    [Header("Info Refs")]
    public TMP_Text healthText;
    public TMP_Text atkText;

    public TMP_Text weaponText;
    public TMP_Text armorText;
    public Image weaponImage;
    public Image armorImage;

    public levelPips weaponPip;
    public levelPips armorPip;


    void Start()
    {
        Color weaponColor, armorColor;
        ColorUtility.TryParseHtmlString("#FF6347", out weaponColor);
        ColorUtility.TryParseHtmlString("#1E90FF", out armorColor);

        weaponText.color = weaponColor;
        armorText.color = armorColor;

        if(!GameState.Instance.testingMode)
        {
            health = GameState.Instance.currPlayerInfo.health;
            attack = GameState.Instance.currPlayerInfo.attack;
        }

        currentWeapon = GetComponentInChildren<weapon>();
        currentArmor = GetComponentInChildren<armor>();

        if (!GameState.Instance.testingMode)
        {
            maxAttack = tierToMaxAttack(GameState.Instance.getCurrTier());
            maxHealth = tierToMaxHealth(GameState.Instance.getCurrTier());

            refreshStats();

        }

    }

    public int tierToMaxHealth(int tier)
    {
        return 10 + tier * 20;
    }

    public int tierToMaxAttack(int tier)
    {
        return 10 + tier * 20;
    }

    public void refreshStats()
    {

        healthText.text = "Health: " + health;
        atkText.text = "Attack: " + attack;

        weaponText.text = currentWeapon.upgradeName;
        weaponImage.sprite = currentWeapon.upgradeSprite;
        armorText.text = currentArmor.upgradeName;
        armorImage.sprite = currentArmor.upgradeSprite;


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

    public void applyBuffs(buff newBuff)
    {
        switch(newBuff.mainStat)
        {
            case stats.atk:
                if (newBuff.isSuperBuff)
                {
                    attack = Mathf.CeilToInt(Mathf.Min(maxAttack, attack * newBuff.multiplier));
                   
                }
                else
                {
                    attack = Mathf.Min(attack + newBuff.statDif, maxAttack);
                }
                break;

            case stats.hp:
                if (newBuff.isSuperBuff)
                {
                    health = Mathf.CeilToInt(Mathf.Min(maxAttack, health * newBuff.multiplier));

                }
                else
                {
                    health = Mathf.Min(health + newBuff.statDif, maxHealth);
                }
                break;
        }

        refreshStats();
    }

    public void applyDebuffs(buff newBuff)
    {
        switch (newBuff.secondaryStat)
        {
            case stats.atk:
                attack = Mathf.Max(1, attack - newBuff.statDif);
                break;

            case stats.hp:
                health = Mathf.Max(1, health - newBuff.statDif);
                break;
        }

        refreshStats();
    }


}


