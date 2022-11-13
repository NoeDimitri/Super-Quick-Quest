using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public encounter currEncounter;

    private playerInfo currPlayerInfo;
    public playerCharacter shoppingChar;

    public int currTier;

    // Start is called before the first frame update
    void Start()
    {
        currTier = 1;
        currPlayerInfo = GetComponent<playerInfo>();
        shoppingChar = GameObject.FindGameObjectWithTag("Player").GetComponent<playerCharacter>();
        //if instance is null;
    }

    private void OnEnable()
    {
        shopTimer.timerFinished += saveCharacter;
    }
    private void OnDisable()
    {
        shopTimer.timerFinished -= saveCharacter;
    }

    void saveCharacter()
    {
        currPlayerInfo.clone(shoppingChar);
    }

    public int getCurrTier()
    {
        return currTier;
    }


}
    