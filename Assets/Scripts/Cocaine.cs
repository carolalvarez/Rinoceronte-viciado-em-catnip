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
    GameManager gameManager;
    float temp = 0;
    float time = 0;
    float tempSprite = 0;
    [SerializeField]
    Sprite rinoSnif, rinoSnifnt;
    [SerializeField]
    GameObject rinoBack;
    [SerializeField]
    AudioSource rinoSniffSound;

    bool sniffing;
    void Start()
    {
        rinoSniffSound = GetComponent<AudioSource>();
        sniffing = false;
        temp = 0;
        time = 0;
        tempSprite = 0;
        gameManager = FindObjectOfType<GameManager>();
        slider.maxValue = SlideMaxValue;
    }
    void Update()
    {
        Debug.Log(sniffing);

        if (sniffing)
        {
            rinoSniffSound.Play();
            rinoBack.GetComponent<SpriteRenderer>().sprite = rinoSnif;
        }
        else
            rinoBack.GetComponent<SpriteRenderer>().sprite = rinoSnifnt;

        slider.value = SlideValue;
        if (Input.GetMouseButtonDown(1)|| Input.GetMouseButtonDown(0))
        {
            tempSprite = 0;
            sniffing = true;

            if (SlideValue >= SlideMaxValue)
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
        tempSprite += Time.deltaTime;
        if(tempSprite>0.5)
        {
            sniffing = false;
        }

        temp += Time.deltaTime;
        time += Time.deltaTime;

        if(temp >= 0.25)
        {
            if (SlideValue > 0)
            {              
                SlideValue -= 1;
            }
            else
            {
                SlideValue = 0;
            }
            temp = 0;
        }

        if(time >= 8)
        {
            temp = 0;
            time = 0;
            tempSprite = 0;
            gameManager.SetMaxHealth(SlideValue);
            SceneManager.LoadScene(2);
        }
        
    }
}
