using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelPips : MonoBehaviour
{
    int level = 0;
    public SpriteRenderer[] pips;

    public Color fadedColor, activatedColor, maxedColor;

    void Start()
    {

    }

    //Sets current number of pips to glow
    public void updatePips(int newLevel)
    {
        level = newLevel;

        for(int i = 0; i < pips.Length; i++)
        {
            if(i < level)
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
