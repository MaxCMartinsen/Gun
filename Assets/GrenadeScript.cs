using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    public float timer;
    private SphereCollider SphereCollider;
    public GameObject bullet;
    public float rotX = 0;

    // Start is called before the first frame update
    void Start()
    {
        SphereCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 4.99f)
        {
            SphereCollider.radius = 1f;
            SphereCollider.isTrigger = true;
            for (int i = 0; i < 16; i++)
            {
                Debug.Log(i);
                SpawnBullet();
            }
        }
        if (timer > 5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Wall")
        {
            Destroy(other.gameObject);
        }
    }

    void SpawnBullet()
    {
        rotX += 1;
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Quaternion rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y + (11.25f * rotX), transform.rotation.z);
        Instantiate(bullet, pos, rot);
    }
}
