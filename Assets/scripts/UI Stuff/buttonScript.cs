using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{

    public Button restartButton, exitGameButton;

    private void Start()
    {
        restartButton.onClick.AddListener(loadStart);
        exitGameButton.onClick.AddListener(closeGame);
    }

    void loadStart()
    {
        destroyAudio();
        SceneManager.LoadScene("shopScene");

    }

    void closeGame()
    {
        Application.Quit();
    }
    void destroyAudio()
    {
        if (GameObject.FindGameObjectWithTag("musicPlayer") != null)
        {

            Destroy(GameObject.FindGameObjectWithTag("musicPlayer"));

        }
    }
}
