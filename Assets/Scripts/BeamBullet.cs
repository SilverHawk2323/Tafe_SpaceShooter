using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBullet : Bullet
{
    public void Start()
    {
        transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3.8f);
        player = GameManager.gm.GetPlayerRef();
    }

    public override void Hit(Collision other)
    {
        Instantiate(explosion, other.transform.position, Quaternion.identity);
        Destroy(other.gameObject);
    }

    private void Update()
    {
        //to make sure the beam follows where the player moves
        transform.position = new Vector3(player.firepoint.transform.position.x, player.firepoint.transform.position.y, player.firepoint.transform.position.z + 4.5f);

        //once the player lets go of shoot button the laser destroys itself
        if (Input.GetButtonUp("Shoot"))
        {
            Debug.Log("Destroy Laser");
            Destroy(gameObject);
        }
    }
}
