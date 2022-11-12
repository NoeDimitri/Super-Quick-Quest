using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerCharacter : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Player Stats")]
    public int health;
    public int attack;
    public int speed;

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


    void Start()
    {
        refreshStats();
        Color weaponColor, armorColor;
        ColorUtility.TryParseHtmlString("#FF6347", out weaponColor);
        ColorUtility.TryParseHtmlString("#1E90FF", out armorColor);

        weaponText.color = weaponColor;
        armorText.color = armorColor;

    }

    // Update is called once per frame


    public void resetEquipment()
    {



    }

    public void refreshStats()
    {
        healthText.text = "Health: " + health;
        atkText.text = "Attack: " + attack;
        spdText.text = "Speed: " + speed;

        weaponText.text = currentWeapon.upgradeName;
        armorText.text = currentArmor.upgradeName;

    }



}


