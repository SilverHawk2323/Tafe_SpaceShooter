using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public Text timerText;
    public Text livesText;
    float timer;

    public static GameManager gm;
    public bool playing;
    public int lives;
    public GameObject astriod;
        
    // Start is called before the first frame update
    void Start()
    {
        gm = this;
        timer = 0;
        playing = true;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            timer += Time.deltaTime;
            timerText.text = "Time: " + Mathf.Round(timer * 100) / 100;
            livesText.text = "Lives: " + lives;
        }
    }

    public void Reset()
    {

        if (lives == 0 )
        {
            playing = false;
            SceneManager.LoadScene(0);
        }
        else
        {
            
            
            
        }
        

    }

}
