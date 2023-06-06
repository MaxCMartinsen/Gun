using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject tracerBullet;
    private GameObject player;
    public GameObject bulletHolePrefab;
    public GameObject objectToIgnore1;
    public GameObject objectToIgnore2;
    public GameObject flashlight;
    public GameObject grenade;
    public GameObject casing;
    private bulletScript Bscript;
    public Text magText;
    private Quaternion rotation;
    private Quaternion PlayerRotation;
    // Counter to make sure every 10 is tracer
    private float counterTracer = 0.0f;
    // Timers
    public float shootTimer = 2.0f;
    public float reloadTimer = 0.0f;

    // Magazines
    public int sprayMag = 100;
    public int pistolMag = 10;

    // Speed of bullet
    public float bulletSpeed;
    // Gun shoot quick (On/Off)
    public bool spray;
    // Gun shoot tracer (On/Off)
    public bool tracer;
    public bool spread;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Bscript = bullet.GetComponent<bulletScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRotation = transform.rotation;

        magText.text = "Pistol Mag: " + pistolMag + "\nSMG Mag: " + sprayMag;
        // Reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            pistolMag = 10;
            sprayMag = 100;
        }
        // Spray On or Off
        if (Input.GetKeyDown(KeyCode.U))
        {
            spray = !spray;
        }
        // Tracer On or Off
        if (Input.GetKeyDown(KeyCode.Y))
        {
            tracer = !tracer;
        }
        // Spread On or Off
        if (Input.GetKeyDown(KeyCode.I))
        {
            spread = !spread;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            flashlight.SetActive(!flashlight.active);
        }

        if (!spray)
        {
            // Pistol Shooting
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (pistolMag > 0)
                {
                    if (shootTimer > 0.3)
                    {
                        shootTimer = 0;
                        ShootBullet(bullet);
                        pistolMag--;
                    }
                }
            }
            shootTimer += Time.deltaTime;

        } else
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                // S
                if (sprayMag > 0)
                {
                    if (shootTimer > 0.03)
                    {
                        if (!tracer)
                        {
                            shootTimer = 0;
                            ShootBullet(bullet);
                            sprayMag--;
                        }
                        else
                        {
                            // Tracer Shooting
                            if (counterTracer < 10)
                            {
                                shootTimer = 0;
                                ShootBullet(bullet);
                                counterTracer++;
                                sprayMag--;
                            }
                            else
                            {
                                shootTimer = 0;
                                counterTracer = 0;
                                ShootBullet(tracerBullet);
                                sprayMag--;
                            }

                        }
                    }
                }
                
                
            }
            shootTimer += Time.deltaTime;
        }
        reloadTimer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.localPosition = new Vector3(0, 0.2f, 0.65f);
        }
        else
        {
            transform.localPosition = new Vector3(0.371f, 0.133f, 0.65f);
        }

        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            Instantiate(grenade, transform.position, PlayerRotation);
        }
    }

    void ShootBullet(GameObject bulletType)
    {
        GameObject activeBullet = Instantiate(bulletType, transform.position, transform.localRotation);
        Rigidbody rb = activeBullet.GetComponent<Rigidbody>();
        rb.AddForce(gameObject.transform.up * bulletSpeed, ForceMode.Impulse);
        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit hit;

        if (objectToIgnore1 != null && objectToIgnore2 != null)
        {
            int layerMask = 1 << objectToIgnore1.layer | 1 << objectToIgnore2.layer;

            if (Physics.Raycast(ray, out hit, 100f, ~layerMask))
            {
                GameObject sphere = Instantiate(bulletHolePrefab, hit.point, hit.transform.rotation);

                if (hit.collider.name == "Grenade")
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
        float timer = 0f;
        Vector3 xyz = new Vector3(transform.position.x  +0.1f, transform.position.y + 0.1f, transform.position.z);
        GameObject bulletCasing = Instantiate(casing, xyz, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z));
        if (timer < 0.1f)
        {
            bulletCasing.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 5, ForceMode.Impulse);
        }
        if (timer > 1f)
        {
            Destroy(bulletCasing);
        }
        gameObject.GetComponent<AudioSource>().Play();
    }

}
