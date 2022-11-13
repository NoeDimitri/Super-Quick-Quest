using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class shopListing : MonoBehaviour
{
    // Start is called before the first frame update
    public enum listingType {buff, armor, weapon};
    private shopScript shop;
    [SerializeField]
    private playerCharacter player;

    [Header("Info")]
    public TMP_Text Title;
    public TMP_Text Description;
    public TMP_Text penalty;
    public Image itemSprite;
    private SpriteRenderer listingColor;

    [Space(10)]
    public listingType shopType;
    [Space(5)]

    [Header("Current Upgrades")]
    public weapon currentWeapon;
    public armor currentArmor;
    public buff currentBuff;

    void Awake()
    {
        listingColor = GetComponent<SpriteRenderer>();
        shop = GetComponentInParent<shopScript>();
        shop.rerollShop();
    }


    public void displayInfo()
    {
        switch(shopType)
        {
            case listingType.armor:
                displayInfoHelper(currentArmor);

                break;
            case listingType.weapon:
                displayInfoHelper(currentWeapon);

                break;
            case listingType.buff:
                displayInfoHelper(currentBuff);
                break;

        }
    }

    private void displayInfoHelper(upgrades newUpgrade)
    {

        Title.text = newUpgrade.upgradeName;
        Description.text = newUpgrade.upgradeDescription;
        listingColor.color = newUpgrade.returnUpgradeColor();
        itemSprite.sprite = newUpgrade.upgradeSprite;
        penalty.text = newUpgrade.penalty;

    }

    public void selectListing()
    {

        switch (shopType)
        {
            case listingType.armor:
                player.equipArmor(currentArmor);
                break;
            case listingType.weapon:
                player.equipWeapon(currentWeapon);
  
                break;
            case listingType.buff:
                player.applyBuffs(currentBuff);
                if(currentBuff.isSuperBuff)
                {
                    player.applyDebuffs(currentBuff);
                }
                break;

        }

        shop.loseTime();
        shop.rerollShop();
        displayInfo();
    }


}
