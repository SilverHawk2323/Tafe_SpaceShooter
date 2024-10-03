using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    public float topSpeed;
    public float bottomSpeed;
    float speed;
    public MeshRenderer meshRenderer;
    private Material[] asteroidMaterials;
    public float dissolveRate = 0.0125f;
    public float refreshRate = 0.025f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        speed = Random.Range(bottomSpeed, topSpeed);

        Vector3 rot;

        rot.x = Random.Range(-20f, 20f);
        rot.y = Random.Range(-20f, 20f);
        rot.z = Random.Range(-20f, 20f);

        rb.AddTorque(rot);

        if (meshRenderer != null)
        {
            asteroidMaterials = meshRenderer.materials;
        }

        transform.localScale = Vector3.one * Random.Range(1f, 3f);

        Destroy(gameObject, Random.Range(8f, 10f));
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.playing == false)
        {
            return;
        }
        rb.AddForce(Vector3.back * Time.deltaTime * speed);
    }

    public void OnDestroy()
    {
        Spawner.ins.DeactivateAsteroid(gameObject);
    }

    public void Reset()
    {

        Destroy(gameObject);
    }

    public IEnumerator DissolveCo()
    {
        bool dissolveEffectRunning = false;
        if (!dissolveEffectRunning)
        {
            dissolveEffectRunning = true;
            if (asteroidMaterials.Length > 0)
            {
                float counter = 0;

                while (asteroidMaterials[0].GetFloat("_DissolveAmount") < 1)
                {
                    counter += dissolveRate;
                    for (int i = 0; i < asteroidMaterials.Length; i++)
                    {
                        asteroidMaterials[i].SetFloat("_DissolveAmount", counter);
                    }
                    yield return new WaitForSeconds(refreshRate);
                }
            }
        }
                    
    }
}
