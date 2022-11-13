using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelPips : MonoBehaviour
{

    int level = 1;
    public Image[] pips;

    public Image renderedSprite;

    public Color fadedColor, activatedColor, maxedColor;
    public bool isWeapon;

    void Start()
    {
       
        initPips();


    }

    public void initPips()
    {
        if (isWeapon)
        {
            updatePips(GameState.Instance.currPlayerInfo.currWeapon.getLevel());
        }
        else
        {
            updatePips(GameState.Instance.currPlayerInfo.currArmor.getLevel());
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

