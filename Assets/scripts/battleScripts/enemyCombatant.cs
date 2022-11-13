using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enemyCombatant : combatant
{
    //so i can remove stuff properly
    playerCombatant playerObj;

    public Sprite enemySprite;
    public Image monsterImage;

    public GameObject damageText;

    void Start()
    {
        //I will only try to hit the player
        playerObj = GameObject.FindGameObjectWithTag("player").GetComponent<playerCombatant>();
        target = playerObj;
        currentAtkCharge = Random.Range(0f, 0.25f) * atkChargeMax;
        slider = GetComponentInChildren<Slider>();
        particles = GetComponentInChildren<ParticleSystem>();

    }
    public override void takeDamage(int damage)
    {
        if (damage <= 0)
        {
            return;
        }

        health -= damage;
        particles.Play();

        GameObject damageNums = Instantiate(damageText, transform.position, Quaternion.identity);
        damageNums.GetComponentInChildren<TextMesh>().text = "-" + damage;

        if (health <= 0)
        {
            death();
        }


    }
    protected override void death()
    {
        playerObj.removeEnemy(this);

        Destroy(gameObject, 1f);

    }


}
