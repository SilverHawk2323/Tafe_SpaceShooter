using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        names = Character.Rob;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel;

        vel = transform.right * Input.GetAxisRaw("Horizontal");
        vel += transform.forward * Input.GetAxisRaw("Vertical");


        rb.AddForce(vel * speed);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(names == Character.Gob)
            {
                names = Character.Rob;
                
            }
            else
            {
                names = Character.Bob;
            }
            Debug.Log(names);
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
        }
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

    private void Death(Collision collision)
    {
        Destroy(collision.gameObject);
        GameManager.gm.lives -= 1;
        GameManager.gm.Reset();
        Spawner.ins.DestroyAllAsteroids();
        transform.position = checkpoint.position;
        //Destroy(gameObject);
    }
}
