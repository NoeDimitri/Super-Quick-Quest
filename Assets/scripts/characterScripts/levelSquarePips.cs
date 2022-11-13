using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelSquarePips : MonoBehaviour
{

    int level = 0;
    public Image[] pips;

    public Image renderedSprite;

    public Color fadedColor, activatedColor, maxedColor;
    public bool isWeapon;

    void Start()
    {
        if(!GameState.Instance.testingMode)
        {
            initPips();
        }


    }

    public void initPips()
    {
        if (isWeapon)
        {
             updatePips(GameState.Instance.currPlayerInfo.currWeapon.getLevel());
             renderedSprite.sprite = GameState.Instance.currPlayerInfo.currWeapon.upgradeSprite;
        }
        else
         {
             updatePips(GameState.Instance.currPlayerInfo.currArmor.getLevel());
             renderedSprite.sprite = GameState.Instance.currPlayerInfo.currArmor.upgradeSprite;
         }

    }

    //Sets current number of pips to glow
    public void updatePips(int newLevel)
    {

        level = newLevel;

        for (int i = 0; i < pips.Length; i++)
        {
            if (level >= 3)
            {

                pips[i].color = maxedColor;


            }
            else if (i < level)
            {

                pips[i].color = activatedColor;

            }
            else
            {

                pips[i].color = fadedColor;

            }

        }


    }
}
