using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlasmaBullet : Bullet
{
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameManager.gm.GetPlayerRef();
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        audioManager.PlaySFX(audioManager.plasma);
    }

    private void Update()
    {
        rb.AddForce(transform.up * speed * Time.deltaTime);
        Destroy(gameObject, 3f);
    }

    public override void Hit(Collision other)
    {
        //once hit the asteroid starts the dissolve effect
        other.gameObject.GetComponent<Astroid>().StartCoroutine(other.gameObject.GetComponent<Astroid>().DissolveCo());
        //To stop the asteroid from blocking other asteroids while it dissolves the mesh collider is turned off
        other.gameObject.GetComponent<MeshCollider>().enabled = false;
        //after all this the plasma bullet is destroyed
        Destroy(gameObject);
    }
}
