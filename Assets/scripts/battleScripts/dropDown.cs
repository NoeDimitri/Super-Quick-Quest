using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropDown : MonoBehaviour
{


    public encounter currEncounter;

    public monsterMenu[] currMonstersDisplay;

    public GameObject Panel;


    // Start is called before the first frame update
    void Start()
    {
        int index = 0;
        foreach(monsterInfo monster in currEncounter.monsters)
        {
            currMonstersDisplay[index].enemyDescription.text = monster.description;
            currMonstersDisplay[index].enemyImage.sprite = monster.monsterSprite;
            currMonstersDisplay[index].enemyName.text = monster.monsterName;
            currMonstersDisplay[index].enemyHealth.value = Mathf.Min(monster.health / 100,1);
            currMonstersDisplay[index].enemyAttack.value = Mathf.Min(monster.attack / 100, 1);
            index++;
        }
    }

    public void openMenu()
    {
        if (Panel != null)
        {
            Animator animator = Panel.GetComponent<Animator>();
            if(animator != null)
            {
                animator.SetBool("open", true);
            }
        }
    }
    
    public void closeMenu()
    {
        if (Panel != null)
        {
            Animator animator = Panel.GetComponent<Animator>();
            if(animator != null)
            {
                animator.SetBool("open", false);
            }
        }
    }
}
