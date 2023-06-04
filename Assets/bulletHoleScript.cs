using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHoleScript : MonoBehaviour
{
    private float timer;
    public ParticleSystem hitParticle;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate the particle effect at the bullet hole's position
        ParticleSystem particleInstance = Instantiate(hitParticle, transform.position, Quaternion.identity);

        // Set the rotation of the particle effect to match the bullet hole, but flipped
        Vector3 flippedRotation = transform.rotation.eulerAngles;
        flippedRotation.y += 180f;
        particleInstance.transform.rotation = Quaternion.Euler(flippedRotation);

        // Play the particle effect once
        hitParticle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        

        if (timer > 5)
        {
            Destroy(gameObject);
        }

        
    }
}
