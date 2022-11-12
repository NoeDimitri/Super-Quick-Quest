using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public encounter currEncounter;

    private playerInfo currPlayerInfo;
    public playerCharacter shoppingChar;

    void saveCharacter()
    {
        currPlayerInfo.clone(shoppingChar);
    }



    // Start is called before the first frame update
    void Start()
    {
        currPlayerInfo = GetComponent<playerInfo>();
        shoppingChar = GameObject.FindGameObjectWithTag("Player").GetComponent<playerCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
