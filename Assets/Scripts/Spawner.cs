using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner ins;
    private void Awake()
    {
        ins = this;
    }

    public GameObject[] asteroid;
    public Transform pointA;
    public Transform pointB;
    public float timer;
    public float resetTime;

    public List<GameObject> activeAsteroids = new(); 

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
        GameObject newAsteroid = Instantiate(asteroid[Random.Range(1, 4)], pos, Quaternion.identity);
        activeAsteroids.Add(newAsteroid);

    }

    public void DeactivateAsteroid(GameObject asteroidToDeactivate)
    {
        if (activeAsteroids.Contains(asteroidToDeactivate))
        {
            activeAsteroids.Remove(asteroidToDeactivate);
        }
    }

    public void DestroyAllAsteroids()
    {
        GameObject[] asteroidsInScene = new GameObject[activeAsteroids.Count];
        activeAsteroids.CopyTo(asteroidsInScene);
        foreach (GameObject asteroid in asteroidsInScene)
        {
            Destroy(asteroid);
        }
    }
}
