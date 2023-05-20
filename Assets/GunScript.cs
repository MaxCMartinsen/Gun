using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject tracerBullet;
    private GameObject player;
    private bulletScript Bscript;
    public Text magText;

    private Quaternion rotation;
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
    }

    void ShootBullet(GameObject bulletType)
    {
        GameObject activeBullet = Instantiate(bulletType, transform.position, transform.localRotation);
        Rigidbody rb = activeBullet.GetComponent<Rigidbody>();
        rb.AddForce(gameObject.transform.up * bulletSpeed, ForceMode.Impulse);
    }

}
