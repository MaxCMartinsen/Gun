using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript1 : MonoBehaviour
{
    public float angleSpeed;
    public float timer = 0.0f;
    public float timeAlive;

    public Rigidbody rb;
    public GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gun = GameObject.FindGameObjectWithTag("Gun");

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * angleSpeed * Time.deltaTime);
        timer += Time.deltaTime;

        if (timer > timeAlive)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Bullet (1) Variant(Clone)")
        {
            Debug.Log(other.name);
            Destroy(gameObject);
        }
    }

    
}
