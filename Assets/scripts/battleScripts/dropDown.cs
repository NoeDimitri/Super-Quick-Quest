using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropDown : MonoBehaviour
{
    public delegate void timerStart();
    public static event timerStart timerStarted;

    public encounter currEncounter;

    public monsterMenu[] currMonstersDisplay;

    public GameObject Panel;
    public GameObject blackPanel;

    public bool timerStartedBool;


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

        timerStartedBool = false;


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

        if (!timerStartedBool)
        {
            if (timerStarted != null)
            {
                timerStarted();
            }
        }

    }

    private void OnEnable()
    {
        shopTimer.timerFinished += closeShop;
    }
    private void OnDisable()
    {
        shopTimer.timerFinished -= closeShop;
    }

    public void closeShop()
    {
        if (blackPanel != null)
        {
            Animator animator = blackPanel.GetComponent<Animator>();
            if(animator != null)
            {
                animator.SetBool("open", false);
            }
        }
        else
        {
            Debug.Log("errorrrr");
        }
    }
}
