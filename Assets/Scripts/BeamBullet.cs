using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBullet : Bullet
{
    public void Start()
    {
        transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3.8f);
    }

    public override void Hit(Collision other)
    {
        Instantiate(explosion, other.transform.position, Quaternion.identity);
    }
}
