using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] asteroid;
    public Transform pointA;
    public Transform pointB;
    public float timer;
    public float resetTime;

    

    // Start is called before the first frame update
    void Start()
    {
        timer = resetTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Spawn();
            if (resetTime > 0.5f)
            {
                resetTime -= .1f;
            }
            timer = resetTime;
        }
    }

    void Spawn()
    {
        Vector3 pos = Vector3.Lerp(pointA.position, pointB.position, Random.Range(0f, 1f));
        Instantiate(asteroid[Random.Range(1, 4)], pos, Quaternion.identity);
    }

    
}
