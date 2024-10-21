using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject menu;
    public GameObject controlsMenu;
    public void Continue()
    {
        menu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Controls()
    {
        controlsMenu.SetActive(true);
        menu.SetActive(false);
    }

    public void BeginPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Back()
    {
        controlsMenu.SetActive(false);
        menu.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Goodbye World");
        Application.Quit();
    }
}
