using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    public float topSpeed;
    public float bottomSpeed;
    float speed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = Random.Range(bottomSpeed, topSpeed);

        Vector3 rot;

        rot.x = Random.Range(-20f, 20f);
        rot.y = Random.Range(-20f, 20f);
        rot.z = Random.Range(-20f, 20f);

        rb.AddTorque(rot);

        transform.localScale = Vector3.one * Random.Range(1f, 3f);

        Destroy(gameObject, Random.Range(8f, 10f));
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.back*Time.deltaTime * speed);
    }

    public void Reset()
    {
        Destroy(gameObject);
    }
}
