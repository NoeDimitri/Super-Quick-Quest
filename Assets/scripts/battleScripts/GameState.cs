using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public encounter currEncounter;

    private playerInfo currPlayerInfo;
    public playerCharacter shoppingChar;

    public int currTier;

    void saveCharacter()
    {
        currPlayerInfo.clone(shoppingChar);
    }



    // Start is called before the first frame update
    void Start()
    {
        currPlayerInfo = GetComponent<playerInfo>();
        shoppingChar = GameObject.FindGameObjectWithTag("Player").GetComponent<playerCharacter>();
        //if instance is null;
        currTier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
    