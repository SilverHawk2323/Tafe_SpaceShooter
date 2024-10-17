using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeamBullet : Bullet
{
    private float overheatMax = 6f;
    public float currentOverheat;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3.8f);
        player = GameManager.gm.GetPlayerRef();
    }

    public override void Hit(Collision other)
    {
        GameObject vfx = Instantiate(explosion, other.transform.position, Quaternion.identity);
        Destroy(vfx, 3f);
        Destroy(other.gameObject);
    }

    private void Update()
    {
        currentOverheat += Time.deltaTime;
        GameManager.gm.laserheatUI();
        if (currentOverheat >= overheatMax)
        {
            Destroy(gameObject);
        }

        //to make sure the beam follows where the player moves
        transform.position = new Vector3(player.firepoint.transform.position.x, player.firepoint.transform.position.y, player.firepoint.transform.position.z + 4.5f);

        //once the player lets go of shoot button the laser destroys itself
        if (Input.GetButtonUp("Shoot"))
        {
            Debug.Log("Destroy Laser");
            GameManager.gm.laserAmmo.GetComponent<Slider>().value = 6f;
            Destroy(gameObject);
        }
    }
}
