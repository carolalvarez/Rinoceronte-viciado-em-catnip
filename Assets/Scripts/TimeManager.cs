using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    float time = 100;
    int tMinutos, tSegundos, tDecimasSegundo;
    [SerializeField]
    TMP_Text time_;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(4);
        }
        tMinutos = Mathf.FloorToInt(time / 60);
        tSegundos = Mathf.FloorToInt(time % 60);
        tDecimasSegundo = Mathf.FloorToInt((time % 1) * 100);
        time_.text = string.Format("{0:00}:{1:00}:{2:00}", tMinutos, tSegundos, tDecimasSegundo);
    }
}
