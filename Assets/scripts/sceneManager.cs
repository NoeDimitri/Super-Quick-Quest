using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{

    public playerCharacter shopPlayer;

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            shopPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<playerCharacter>();

        }
    }

    private void OnEnable()
    {
        shopTimer.timerFinished += loadBattleScene;
        playerCombatant.battleWon += loadShopScene;
        playerCombatant.gameOver += loadGameOver;
    }
    private void OnDisable()
    {
        shopTimer.timerFinished -= loadBattleScene;
        playerCombatant.battleWon -= loadShopScene;
        playerCombatant.gameOver -= loadGameOver;


    }

    void loadGameOver()
    {
        deleteTrash();

        Destroy(GameState.Instance.gameObject);

        SceneManager.LoadScene("gameOver");

    }

    void loadShopScene()
    {


        GameState.Instance.currTier++;

        deleteTrash();

        SceneManager.LoadScene("shopScene");


    }

    void deleteTrash()
    {
        foreach (GameObject obj in GameState.Instance.savedObjects)
        {

            Destroy(obj);

        }
        GameState.Instance.savedObjects.Clear();
    }


    void loadBattleScene()
    {

        GameState.Instance.savedObjects.Add(shopPlayer.currentArmor.gameObject);
        shopPlayer.currentArmor.gameObject.transform.SetParent(null);
        DontDestroyOnLoad(shopPlayer.currentArmor);

        GameState.Instance.savedObjects.Add(shopPlayer.currentWeapon.gameObject);
        shopPlayer.currentWeapon.gameObject.transform.SetParent(null);
        DontDestroyOnLoad(shopPlayer.currentWeapon);

        foreach(monsterInfo monster in GameState.Instance.currEncounter.monsters)
        {
            GameState.Instance.savedObjects.Add(monster.gameObject);

            monster.gameObject.transform.SetParent(null);
            DontDestroyOnLoad(monster);
        }

        SceneManager.LoadScene("battleScene");
    }

}
