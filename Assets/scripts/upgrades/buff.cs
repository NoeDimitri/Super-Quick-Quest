using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class buff
{
    [Header("Info")]
    public string upgradeName;
    public string upgradeDescription;
    public Sprite upgradeSprite;
    protected Color associatedColor;

    public string penalty;


    //Is this buff a super buff?
    public bool isSuperBuff;
    static int superBuffRate = 4;

    //What we'll be multiplied by if we are super
    public float multiplier;
    static float maxMult = 0.5f;
    static float minMult = 0.15f;

    //What we add/subtract 
    public int statDif;

    //Primary and secondary stats
    public playerCharacter.stats mainStat;
    public playerCharacter.stats secondaryStat;

    static Dictionary<int, playerCharacter.stats> numToStat = new Dictionary<int, playerCharacter.stats>
    {
        [0] = playerCharacter.stats.hp,
        [1] = playerCharacter.stats.atk,
        [2] = playerCharacter.stats.spd,
        [3] = playerCharacter.stats.def
    };

    static Dictionary<playerCharacter.stats, string> statToString = new Dictionary<playerCharacter.stats, string>
    {
        [playerCharacter.stats.hp] = "Health",
        [playerCharacter.stats.atk] = "Attack",
        [playerCharacter.stats.spd] = "Speed",
        [playerCharacter.stats.def] = "Defense"

    };

    static Sprite[] spriteArray;

    public Color returnUpgradeColor()
    {
        return associatedColor;
    }

    private void Start()
    {
        associatedColor = Color.grey;
    }
    static void LoadSpritesWhenReady(AsyncOperationHandle<Sprite[]> handleToCheck)
    {
        if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            spriteArray = handleToCheck.Result;
        }
    }


    
    public static buff generateRandomBuff()
    {
        buff newBuff = new buff();


        //Determine whether it is a suepr buff
        if (Random.Range(0, 101) <= superBuffRate)
        {
            newBuff.isSuperBuff = true;
            ColorUtility.TryParseHtmlString("#ff9933", out newBuff.associatedColor);

        }
        else
        {
            newBuff.isSuperBuff = false;
            ColorUtility.TryParseHtmlString("#817e7e", out newBuff.associatedColor);

        }

        //Multipler for purposes of super buff
        newBuff.multiplier = 1 + Random.Range(minMult, maxMult);

        //Calculating dif
        newBuff.statDif = Random.Range(1, 4);

        
        int statChoice = Random.Range(0, 3);
        int statChoice2 = Random.Range(0, 3);

        while(statChoice2 == statChoice)
        {
            statChoice2 = Random.Range(0, 3);
        }

        newBuff.mainStat = numToStat[statChoice];
        newBuff.secondaryStat = numToStat[statChoice2];

        AsyncOperationHandle<Sprite[]> spriteHandle = Addressables.LoadAssetAsync<Sprite[]>("Assets/sprites/buffSymbol.png");
        spriteHandle.Completed += LoadSpritesWhenReady;

        newBuff.upgradeSprite = spriteArray[0];
        newBuff.upgradeName = statToString[newBuff.mainStat] + " increase";

        if (newBuff.isSuperBuff)
        {
            newBuff.penalty = "Decrease your " + statToString[newBuff.secondaryStat];
            newBuff.upgradeDescription = string.Format("Multiply your {0}\n x {1:0.##}", statToString[newBuff.mainStat], newBuff.multiplier);

        }
        else
        {
            newBuff.upgradeDescription = "Increase your " + statToString[newBuff.mainStat] + "\n+" + newBuff.statDif;
        }

        return newBuff;

    }
    

}
