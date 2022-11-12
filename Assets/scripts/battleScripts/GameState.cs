using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public encounter currEncounter;

    private playerInfo currPlayerInfo;
    private playerCharacter shoppingChar;

    // Start is called before the first frame update
    void Start()
    {
        currPlayerInfo = GetComponent<playerInfo>();
        shoppingChar = GameObject.FindGameObjectWithTag("Player").GetComponent<playerCharacter>();
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


}
