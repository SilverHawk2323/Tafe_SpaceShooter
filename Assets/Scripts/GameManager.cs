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
    public Text scoreText;
    public int score;
    public float timer;
    public GameObject gameOverScreen;
    public Player player;
    public GameObject laserAmmo;
    public static GameManager gm;
    public bool playing;
    public int lives;
    public GameObject astriod;
    public GameObject[] bombAmmo;
    public GameObject bombAmmoUI;

    public int bAmmo =0;
        
    // Start is called before the first frame update
    void Awake()
    {
        gameOverScreen.SetActive(false);
        gm = this;
        timer = 0;
        playing = true;
        lives = 3;
        RefreshLives();
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playing)
        {
            return;
        }
        if (playing)
        {
            timer += Time.deltaTime;
            timerText.text = "Time: " + Mathf.Round(timer * 100) / 100;
            
        }


    }

    public void Reset()
    {

        if (lives == 0 )
        {
            laserAmmo.SetActive(false);
            bombAmmoUI.SetActive(false);
            playing = false;
            gameOverScreen.SetActive(true);
            //SceneManager.LoadScene(0);
        }
        else
        {
            
            
            
        }
        

    }

    public void LaserheatUI()
    {
        laserAmmo.GetComponent<Slider>().value -= Time.deltaTime;
    }

    public void BombAmmo()
    {
        bombAmmo[bAmmo].SetActive(false);
        bAmmo += 1;
    }

    public void RefreshBombAmmo()
    {
        for (int i = 0; i < bombAmmo.Length; i++)
        {
            bombAmmo[i].SetActive(true);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score.ToString();
    }

    public void RefreshLives()
    {
        livesText.text = "Lives: " + lives;
    }

    public void SetPlayerRef(Player player)
    {
        this.player = player;
    }

    public Player GetPlayerRef()
    {
        return player;
    }
}