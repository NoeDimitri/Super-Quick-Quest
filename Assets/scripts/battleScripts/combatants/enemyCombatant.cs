using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enemyCombatant : combatant
{
    //so i can remove stuff properly
    playerCombatant playerObj;
    private Animation anim;

    public Sprite enemySprite;
    public Image monsterImage;

    void Start()
    {
        //I will only try to hit the player
        playerObj = GameObject.FindGameObjectWithTag("player").GetComponent<playerCombatant>();
        target = playerObj;
        currentAtkCharge = Random.Range(0f, 0.25f) * atkChargeMax;
        slider = GetComponentInChildren<Slider>();
        particles = GetComponentInChildren<ParticleSystem>();
        anim = gameObject.GetComponent<Animation>();
        anim["death"].layer = 5;


    }
    public override void takeDamage(int damage)
    {
        GameObject damageNums;

        if (damage <= 0)
        {
            damageNums = Instantiate(floatingText, transform.position, Quaternion.identity);
            damageNums.GetComponentInChildren<TextMesh>().color = Color.blue;
            damageNums.GetComponentInChildren<TextMesh>().text = "blocked!";
            return;

        }

        health -= damage;
        
        particles.Play();

        damageNums = Instantiate(floatingText, transform.position, Quaternion.identity);
        damageNums.GetComponentInChildren<TextMesh>().text = "-" + damage;

        if (health <= 0)
        {
            death();
        }


    }

    private void Update()
    {

        if (activeCombat)
        {
            currentAtkCharge += Time.deltaTime;
            slider.value = Mathf.Min(currentAtkCharge / atkChargeMax, 1);
            if (currentAtkCharge >= atkChargeMax)
            {

                attackMethod.performAttack(this, target);
                anim.Play("enemyAttack");
                currentAtkCharge = 0;

            }

        }
        updateStats();

    }

    protected override void death()
    {

        anim.Play("death");
        anim.Stop();
        playerObj.removeEnemy(this);


        Destroy(gameObject, 1f);

    }


}
