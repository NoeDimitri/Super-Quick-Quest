using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{

    private Button restartButton;

    private void Start()
    {
        restartButton = GetComponent<Button>();

        restartButton.onClick.AddListener(loadStart);
    }

    void loadStart()
    {

        SceneManager.LoadScene("shopScene");

    }

}
