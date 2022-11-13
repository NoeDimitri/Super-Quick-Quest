using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monsterInfo : MonoBehaviour
{

    public int health;
    public int attack;

    public float atkChargeMax;
    public int defense;

    public generalAttack attackMethod;
    public generalDefend defendMethod;

    public string description;
    public string monsterName;

    public Sprite monsterSprite;



    // Start is called before the first frame update
    void Start()
    {

    }
}