using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class shopListing : MonoBehaviour
{
    // Start is called before the first frame update
    public enum listingType {buff, armor, weapon};
    private shopScript shop;

    [Header("Info")]
    public TMP_Text Title;
    public TMP_Text Description;
    public SpriteRenderer image;
    private SpriteRenderer sprite;

    [Space(10)]
    public listingType shopType;
    [Space(5)]

    [Header("Current Upgrades")]
    public weapon currentWeapon;
    public armor currentArmor;
    public buff currentBuff;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        shop = GetComponentInParent<shopScript>();
    }

    public void displayInfo()
    {
        switch(shopType)
        {
            case listingType.armor:
                Title.text = currentArmor.upgradeName;
                Description.text = currentArmor.upgradeDescription;
                sprite.color = currentArmor.returnUpgradeColor();
                break;
            case listingType.weapon:
                Title.text = currentWeapon.upgradeName;
                Description.text = currentWeapon.upgradeDescription;
                sprite.color = currentWeapon.returnUpgradeColor();

                break;
            case listingType.buff:
                Title.text = currentBuff.upgradeName;
                Description.text = currentBuff.upgradeDescription;
                sprite.color = currentBuff.returnUpgradeColor();

                break;

        }
    }


}
