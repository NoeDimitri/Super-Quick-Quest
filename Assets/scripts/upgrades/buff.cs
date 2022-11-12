using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class buff : upgrades
{
    [Header("generalBuff Info")]
    //Is this buff a super buff?
    public bool isSuperBuff;
    //What we'll be multiplied by if we are super
    public float multiplier;
    public int statDif;
    //Primary and secondary stats
    public playerCharacter.stats mainStat;
    public playerCharacter.stats secondaryStat;

    [Header("Random Buff Rates")]
    public int superBuffRate = 3;
    public float maxMult = 0.5f;
    public float minMult = 0.15f;


    public Dictionary<int, playerCharacter.stats> numToStat = new Dictionary<int, playerCharacter.stats>
    {
        [0] = playerCharacter.stats.hp,
        [1] = playerCharacter.stats.atk,
        [2] = playerCharacter.stats.spd,
        [3] = playerCharacter.stats.def
    };

    public Dictionary<playerCharacter.stats, string> statToString = new Dictionary<playerCharacter.stats, string>
    {
        [playerCharacter.stats.hp] = "Health",
        [playerCharacter.stats.atk] = "Attack",
        [playerCharacter.stats.spd] = "Speed",
        [playerCharacter.stats.def] = "Defense"

    };

    private Sprite[] spriteArray;

    private void Start()
    {
        generateRandomBuff();
    }
    private void LoadSpritesWhenReady(AsyncOperationHandle<Sprite[]> handleToCheck)
    {
        if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            spriteArray = handleToCheck.Result;
        }
    }
    
    //random shuffle this buffs stats
    public void generateRandomBuff()
    {
        //Determine whether it is a suepr buff
        if (Random.Range(0, 101) <= superBuffRate)
        {
            isSuperBuff = true;
            ColorUtility.TryParseHtmlString("#ff9933", out associatedColor);

        }
        else
        {
            isSuperBuff = false;
            ColorUtility.TryParseHtmlString("#817e7e", out associatedColor);

        }

        //Multipler for purposes of super buff
        multiplier = 1 + Random.Range(minMult, maxMult);

        //Calculating dif
        statDif = Random.Range(1, 4);

        
        int statChoice = Random.Range(0, 3);
        int statChoice2 = Random.Range(0, 3);

        while(statChoice2 == statChoice)
        {
            statChoice2 = Random.Range(0, 3);
        }

        mainStat = numToStat[statChoice];
        secondaryStat = numToStat[statChoice2];
        upgradeName = statToString[mainStat] + " increase";

        if (isSuperBuff)
        {
            penalty = "Decrease your " + statToString[secondaryStat];
            upgradeDescription = string.Format("Multiply your {0}\n x {1:0.##}", statToString[mainStat], multiplier);

        }
        else
        {
            penalty = "";
            upgradeDescription = "Increase your " + statToString[mainStat] + "\n+" + statDif;
        }

    }
    

}
