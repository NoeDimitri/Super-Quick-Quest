using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopTimer : MonoBehaviour
{
    public delegate void timerFinish();
    public static event timerFinish timerFinished;

    private Slider slider;
    public float decaySpeed = 0.02f;
    private ParticleSystem particles;

    public float maxTime;
    private float timeRemaining;

    public bool timerStartedBool;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        particles = GetComponentInChildren<ParticleSystem>();
        slider.value = 1;
        timeRemaining = maxTime;

        timerStartedBool = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (timerStartedBool)
        {
            timeRemaining -= Time.deltaTime;

            updateSlider(timeRemaining);

            if (timeRemaining <= 0)
            {
                if (timerFinished != null)
                {
                    timerFinished();
                }

            }
        }
    }

    private void OnEnable()
    {
        dropDown.timerStarted += startTimer;
    }
    private void OnDisable()
    {
        dropDown.timerStarted -= startTimer;
    }

    void startTimer()
    {
        timerStartedBool = true;
    }


    private void updateSlider(float currentTime)
    {
        float currentPercent = currentTime / maxTime;

        slider.value =Mathf.Max(0, currentPercent);


    }

    public void decrementTime(float decrease)
    {

        timeRemaining -= decrease;

    }

    public void playParticles()
    {

        particles.Play();

    }

}
