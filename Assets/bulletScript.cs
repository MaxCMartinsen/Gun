using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
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

        setRotation();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeAlive)
        {
            Debug.Log(transform.position + " , " + transform.rotation);
            Destroy(gameObject);
        }
        if (gun.GetComponent<GunScript>().spread == true)
        {
            transform.Translate(gameObject.transform.forward * angleSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Pistol" && other.name != "Bullet(Clone)" && other.name != "tracerBullet(Clone)")
        {
            Debug.Log(other.name);
            Destroy(gameObject);
        }
    }

    public void setRotation()
    {
        float rndNum = Random.Range(-30f, 30f);
        float angle = rndNum;
        transform.rotation = Quaternion.Euler(transform.rotation.x + angle, transform.rotation.y + angle, transform.rotation.z + angle);
    }
}
