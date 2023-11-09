using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cocaine : MonoBehaviour
{
    float SlideValue= 0;
    [SerializeField]
    float SlideMaxValue = 0;
    [SerializeField]
    float SlideSume = 0;
    [SerializeField]
    Slider slider;

    float temp = 0;
    float time = 0;
    void Start()
    {
        slider.maxValue = SlideMaxValue;
    }
    void Update()
    {
        Debug.Log(SlideValue);
        slider.value = SlideValue;
        if (Input.GetMouseButtonDown(1)|| Input.GetMouseButtonDown(0))
        {
            if(SlideValue >= SlideMaxValue)
            {
                SlideValue = SlideMaxValue;
            }
            else if(SlideValue <= SlideMaxValue*0.5)
            {
                SlideValue += SlideSume;
            }
            else if(SlideValue >= SlideValue*0.5 && SlideValue <= SlideMaxValue*0.33)
            {
                SlideValue += SlideSume*0.75f;
            }
            else 
            {
                SlideValue += SlideSume*0.5f;
            }
        }
        temp += Time.deltaTime;
        time += Time.deltaTime;
        if(temp >= 0.25)
        {
            if (SlideValue > 0)
                SlideValue -= 1;
            else
                SlideValue = 0;

            temp = 0;
        }
        if(time >= 5)
        {
            SceneManager.LoadScene(1);
        }
        
    }
}
