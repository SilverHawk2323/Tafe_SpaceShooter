using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ExplosiveBullet : Bullet
{
    [SerializeField] private float radiusCast = 20f;
    [SerializeField] private int layermask = 6;
    //private Rigidbody rb;
    




    public override void Hit(Collision other)
    {
        Debug.Log("Hit" + other.gameObject);
        //An array for the asteroids caught in the explosion
        Collider[] collision;
        //spawns the VFX explosion
        //GameObject vfx = Instantiate(explosion, other.transform.position, Quaternion.identity);
        //destroys vfx
        //Destroy(vfx, 4f);
        //Gets all the asteroids caught in the explosion
        collision = Physics.OverlapSphere(transform.position, radiusCast, layermask);

        //goes through all the asteroids in the array and destroys them
        foreach(Collider c in collision)
        {
            c.gameObject.GetComponent<Astroid>().StartCoroutine(c.GetComponent<Astroid>().DissolveCo());
            //Destroy(c.gameObject);
        }
        Destroy(gameObject);
    }
}
