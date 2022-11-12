using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderScript : MonoBehaviour
{

    private Slider slider;
    private float targetValue = 0;
    public float fillSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value > targetValue)
        {
            slider.value -= fillSpeed + Time.deltaTime;
        }
        
    }

    public void changeProgress(float newProgress)
    {
        targetValue = slider.value + newProgress;
    }

}
