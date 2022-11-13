using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource[] music;
    private void Start()
    {

        if (GameObject.FindGameObjectsWithTag("musicPlayer") != null && GameObject.FindGameObjectWithTag("musicPlayer") != gameObject)
        {
            return;
        }


        music = GetComponentsInChildren<AudioSource>();

        music[Random.Range(0, music.Length)].Play();

        DontDestroyOnLoad(gameObject);
    }


}
