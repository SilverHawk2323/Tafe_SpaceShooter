using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public Renderer ship;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        names = Character.Rob;
        SwitchBullets();
        GameManager.gm.SetPlayerRef(this);
        ship = this.GetComponentInChildren<Renderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(GameManager.gm.playing == false)
        {
            return;
        }
        Vector3 vel;
        
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
        if (names == Character.Rob && collision.transform.tag == "Asteroid Rob")
        {
            Death(collision);
        }
        if (names == Character.Bob && collision.transform.tag == "Asteroid Bob")
        {
            Death(collision);
        }
        if (names == Character.Gob && collision.transform.tag == "Asteroid Gob")
        {
            Death(collision);
        }
    }

    private void Fire()
    {
        Instantiate(selectedBullet, firepoint.position, Quaternion.identity);
        

    }

    private void Death(Collision collision)
    {
        Destroy(collision.gameObject);
        GameManager.gm.lives -= 1;
        GameManager.gm.Reset();
        Spawner.ins.DestroyAllAsteroids();
        transform.position = checkpoint.position;
        //Destroy(gameObject);
    }

    

    private void SwitchBullets()
    {
        switch (names)
        {
            case Character.Rob:
                selectedBullet = bullets[0];
                break;
            case Character.Bob:
                selectedBullet = bullets[1];
                break;
            case Character.Gob:
                selectedBullet = bullets[2];
                break;
            default:
                Debug.LogWarning("Couldn't Find Bullet");
                break;
        }
    }
}
