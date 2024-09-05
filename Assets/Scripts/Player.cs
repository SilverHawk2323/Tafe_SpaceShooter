using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public Transform checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel;

        vel = transform.right * Input.GetAxisRaw("Horizontal");
        vel += transform.forward * Input.GetAxisRaw("Vertical");


        rb.AddForce(vel * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Asteroids")
        {
            Destroy(collision.gameObject);
            GameManager.gm.lives -= 1;
            GameManager.gm.Reset();
            transform.position = checkpoint.position;
            //Destroy(gameObject);
        }
    }
}
