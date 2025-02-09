using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

/* different characters to avoid different asteroids
 * Switch characters mid gameplay at the press of a button
 * 
 * if the player presses Q or E they switch to a different state
 * a enum would be needed to keep track of the different states
 * a function runs when the player is hit to see if that asteroid is the one that kills that character
 * Asteroids have a master class 
 * the other asteroids override the death function
 * 
 * 
 */

public enum Character
{
    Rob,
    Bob,
    Gob,
}


public class Player : MonoBehaviour
{
    public Character names;
    private Rigidbody rb;
    public float speed;
    public Transform checkpoint;
    public Transform firepoint;
    public GameObject[] bullets;
    public GameObject selectedBullet;
    private int bombAmmo;
    private int maxBombAmmo = 3;
    [SerializeField] private MeshRenderer ship;
    public Material[] bobColour;
    public Material[] robColour;
    public Material[] gobColour;
    private AudioManager audioManager;
    public GameObject pauseMenu;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        names = Character.Rob;
        SwitchBullets();
        GameManager.gm.SetPlayerRef(this);
        bombAmmo = maxBombAmmo;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(GameManager.gm.playing == false)
        {
            return;
        }
        Vector3 vel;

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale > 0f)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
        }
        if (Time.timeScale < 1f)
        {
            return;
        }

            if (Input.GetKeyDown(KeyCode.Q))
        {
            if (names == Character.Gob)
            {
                names = Character.Rob;
            }
            else
            {
                names = Character.Bob;
            }
            Debug.Log(names);
            SwitchBullets();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (names == Character.Bob)
            {
                names = Character.Rob;
            }
            else
            {
                names = Character.Gob;
            }
            Debug.Log(names);
            SwitchBullets();
        }

        vel = transform.right * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        vel += transform.forward * Input.GetAxisRaw("Vertical") * Time.deltaTime;

        if (Input.GetButtonDown("Shoot")) //&& names != Character.Gob) 
        {
            Fire();
        }



        rb.AddForce(vel * speed);
        
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Asteroids")
        {
            audioManager.PlaySFX(audioManager.death);
            Death(collision);
        }
        
    }

    private void Fire()
    {
        if (bombAmmo == 0 && names == Character.Bob)
        {
            return;
        }
        Instantiate(selectedBullet, firepoint.position, Quaternion.identity);
        if (selectedBullet == bullets[1])
        {
            GameManager.gm.BombAmmo();
            bombAmmo -= 1;
        }
    }

    private void Death(Collision collision)
    {
        Destroy(collision.gameObject);
        GameManager.gm.lives -= 1;
        GameManager.gm.RefreshLives();
        GameManager.gm.Reset();
        Spawner.ins.DestroyAllAsteroids();
        transform.position = checkpoint.position;
    }

    

    private void SwitchBullets()
    {
        
        switch (names)
        {
            case Character.Rob:
                selectedBullet = bullets[0];
                GameManager.gm.laserAmmo.SetActive(false);
                GameManager.gm.bombAmmoUI.SetActive(false);
                break;
            case Character.Bob:
                selectedBullet = bullets[1];
                GameManager.gm.laserAmmo.SetActive(false);
                GameManager.gm.bombAmmoUI.SetActive(true);
                GameManager.gm.RefreshBombAmmo();
                GameManager.gm.bAmmo = 0;
                bombAmmo = maxBombAmmo;
                Debug.Log(bombAmmo.ToString());
                break;
            case Character.Gob:
                selectedBullet = bullets[2];
                GameManager.gm.laserAmmo.SetActive(true);
                GameManager.gm.bombAmmoUI.SetActive(false);
                break;
            default:
                Debug.LogWarning("Couldn't Find Bullet");
                break;
        }
        ChangeShipColour();
    }

    public void ChangeShipColour()
    {
        switch (names)
        {
            case Character.Rob:
                for(int i = 0; i < 4; i++)
                {
                    Debug.Log("Changed Colour");
                    ship.materials[i].color = robColour[i].color;
                }
                Debug.Log("ROB'S COLOUR");
                break;
            case Character.Gob:
                for (int i = 0; i < 4; i++)
                {
                    Debug.Log("Changed Colour");
                    ship.materials[i].color = gobColour[i].color;
                }
                break;
            default:
                for (int i = 0; i < 4; i++)
                {
                    ship.materials[i].color = bobColour[i].color;
                }
                Debug.Log("NORMAL COLOUR");
                break;
        }
    }
}
