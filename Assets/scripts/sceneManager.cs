using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    private void OnEnable()
    {
        shopTimer.timerFinished += loadBattleScene;
    }
    private void OnDisable()
    {
        shopTimer.timerFinished -= loadBattleScene;
    }


    void loadBattleScene()
    {
        SceneManager.LoadScene("battleScene");
    }

}
