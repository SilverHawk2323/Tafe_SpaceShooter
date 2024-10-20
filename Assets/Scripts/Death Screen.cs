using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public Text deathText;

    void OnEnable()
    {
        //A local float variable is created to store the timer but rounded up otherwise the timer will have too many decimals
        float localTimer;
        localTimer = Mathf.Round(GameManager.gm.timer * 100) / 100;
        deathText.text = "Your score was:" + "\n" + GameManager.gm.score + "\nNice Work!!!" + "\nYou survived for " + localTimer.ToString() + " seconds";

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
