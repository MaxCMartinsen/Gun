using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour
{
    Ray laserRay;
    Vector3 origin;
    Vector3 direction;
    public float maxDistance = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        origin = transform.position;
        direction = transform.up;
        laserRay = new Ray(origin, direction);
        RaycastHit hit;

        if (Physics.Raycast(laserRay, out hit, maxDistance))
        {
            float distance = Vector3.Distance(laserRay.origin, hit.point);
            Debug.Log("Distance: " + distance);
        }


    }
}
