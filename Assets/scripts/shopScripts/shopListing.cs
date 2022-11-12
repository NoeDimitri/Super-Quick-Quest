using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


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
    public SpriteRenderer itemSprite;
    private SpriteRenderer listingColor;

    [Space(10)]
    public listingType shopType;
    [Space(5)]

    [Header("Current Upgrades")]
    public weapon currentWeapon;
    public armor currentArmor;
    public buff currentBuff;

    void Start()
    {
        listingColor = GetComponent<SpriteRenderer>();
        shop = GetComponentInParent<shopScript>();
    }

    public void displayInfo()
    {
        switch(shopType)
        {
            case listingType.armor:
                Title.text = currentArmor.upgradeName;
                Description.text = currentArmor.upgradeDescription;
                listingColor.color = currentArmor.returnUpgradeColor();
                itemSprite.sprite = currentArmor.upgradeSprite;

                penalty.text = "";
                break;
            case listingType.weapon:
                Title.text = currentWeapon.upgradeName;
                Description.text = currentWeapon.upgradeDescription;
                listingColor.color = currentWeapon.returnUpgradeColor();
                itemSprite.sprite = currentWeapon.upgradeSprite;
                penalty.text = "";
                break;
            case listingType.buff:
                Title.text = currentBuff.upgradeName;
                Description.text = currentBuff.upgradeDescription;
                listingColor.color = currentBuff.returnUpgradeColor();
                itemSprite.sprite = currentBuff.upgradeSprite;
                penalty.text = currentBuff.penalty;
                break;

        }
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
