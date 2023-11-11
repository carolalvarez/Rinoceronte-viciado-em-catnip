using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    GameObject Normal, Menu;
    bool Mute = false;
    [SerializeField]
    Button button;
    [SerializeField]
    Sprite mute, notMute;

    private void Start()
    {
        button.GetComponent<Image>().sprite = notMute;
        AudioListener.volume = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ActivarMenu();
        }
    }

    void ActivarMenu()
    {
        Time.timeScale = 0;
        Normal.SetActive(false);
        Menu.SetActive(true);
    }
    public void DesactivarMenu()
    {
        Time.timeScale = 1;
        Normal.SetActive(true);
        Menu.SetActive(false);
    }
    public void MuteEvent()
    {
       if(!Mute)
        {
            button.GetComponent<Image>().sprite = mute;
            AudioListener.volume = 0;
            Mute = true;
        }
        else
        {
            button.GetComponent<Image>().sprite = notMute;
            AudioListener.volume = 1;
            Mute = false;
        }
    }
    public void GoMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

}
