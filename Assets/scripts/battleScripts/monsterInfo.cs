using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monsterInfo : MonoBehaviour
{

    public string monsterName;
    [TextArea(8, 15)]
    public string description;

    public int health;
    public int attack;

    public float atkChargeMax;
    public int defense;

    public generalAttack attackMethod;
    public generalDefend defendMethod;

    public Sprite monsterSprite;



    // Start is called before the first frame update
    void Start()
    {

    }
}