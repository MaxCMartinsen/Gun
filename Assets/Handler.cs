using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour
{
    Animator animator;
    GunScript script;
    float timer;
    float timerX;
    bool t;
    bool x;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        script = GetComponent<GunScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("isFiring", true);
            t = true;
        }
        if (t)
        {
            timer += Time.deltaTime;
        }

        if (timer > 0.1)
        {
            animator.SetBool("isFiring", false);
            timer = 0;
            t = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool("isReloading", false);
        }


        if (script.pistolMag <= 0)
        {
            animator.SetBool("isReloading", true);
        }
    }
}
