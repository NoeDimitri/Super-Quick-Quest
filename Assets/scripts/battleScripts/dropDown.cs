using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropDown : MonoBehaviour
{
    public delegate void timerStart();
    public static event timerStart timerStarted;

    public tierPool[] currEncounters;
    public encounter currEncounter;

    public monsterMenu[] currMonstersDisplay;

    public GameObject Panel;
    public GameObject blackPanel;

    public bool timerStartedBool;

    private int currTier;
    // Start is called before the first frame update
    void Start()
    {

        currTier = GameState.Instance.currTier;

        currEncounter = currEncounters[currTier - 1].getEncounter(Mathf.FloorToInt(Random.Range(0, (currEncounters[currTier - 1]).getLength())));

        GameState.Instance.currEncounter = currEncounter;


        int index = 0;
        foreach(monsterInfo monster in currEncounter.monsters)
        {
            currMonstersDisplay[index].enemyDescription.text = monster.description;
            currMonstersDisplay[index].enemyImage.sprite = monster.monsterSprite;
            currMonstersDisplay[index].enemyName.text = monster.monsterName;
            currMonstersDisplay[index].enemyHealth.value = Mathf.Min((float)monster.health / 100,1);
            currMonstersDisplay[index].enemyAttack.value = Mathf.Min((float)monster.attack / 100, 1);
            index++;
        }

        while(index < 5)
        {
            currMonstersDisplay[index].gameObject.SetActive(false);
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
