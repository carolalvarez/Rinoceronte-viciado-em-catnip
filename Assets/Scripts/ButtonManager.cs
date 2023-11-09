using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    GameObject controles;
    [SerializeField]
    GameObject menuInicial;
    public void Reiniciar()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuInicial()
    {
        SceneManager.LoadScene(0);
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void IniciarPartida() 
    {
        SceneManager.LoadScene(1);
    }
    public void Controles()
    {
        menuInicial.SetActive(false);
        controles.SetActive(true);
    }
    public void NoControles()
    {
        menuInicial.SetActive(true);
        controles.SetActive(false);
    }
}
