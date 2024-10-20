using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * I need this script to have it so it can act differently when it hits an object
 * 
 * Having a master bullet that has the functions of what to do when it hits an object would work
 * 
 * I would have the OnCollision Event in here as it would be the same across all of them
 * 
 * The Hit explosion would be different and needs to be changed 
 * I could have it as a public variable and it's just different for each prefab
 * I need it so the explosion VFX also destroys the asteroids around it
 */



public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected GameObject explosion;
    protected Rigidbody rb;
    public Player player;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameManager.gm.GetPlayerRef();
    }
    private void Update()
    {
        rb.AddForce(transform.forward * speed * Time.deltaTime);
        Destroy(gameObject, 3f); 
    }


    public abstract void Hit(Collision other);
    public void OnCollisionEnter(Collision collision)
    {
        GameManager.gm.UpdateScore(collision.gameObject.GetComponent<Astroid>().value);
        Hit(collision);
    }
    

}
