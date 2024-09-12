using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public Text scoreText;

    void OnEnable()
    {
        scoreText.text = "You survived for " + GameManager.gm.timer.ToString() + " seconds";

    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }

    public void Leave()
    {
        Debug.Log("Leave");
        Application.Quit();
    }
}
