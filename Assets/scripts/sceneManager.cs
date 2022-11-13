using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{

    private void OnEnable()
    {
        shopTimer.timerFinished += loadBattle;
    }
    private void OnDisable()
    {
        shopTimer.timerFinished -= loadBattle;
    }


    void loadBattle()
    {
        SceneManager.LoadScene("battleScene");
    }


}
