using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class shopListing : MonoBehaviour
{
    // Start is called before the first frame update
    enum listingType {statBuff, equipment};

    public TMP_Text Title, Description;

    listingType shopType;
    public equipment currentItem;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void displayInfo()
    {



    }
    

    bool isEquipment()
    {
        return shopType.Equals(listingType.equipment);
    }

    bool isBuff()
    {
        return shopType.Equals(listingType.statBuff);
    }

}
