using UnityEngine;
using System.Collections;

public class laserScript : MonoBehaviour
{
    public GameObject spherePrefab;
    public GameObject objectToIgnore1;
    public GameObject objectToIgnore2;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (objectToIgnore1 != null && objectToIgnore2 != null)
        {
            int layerMask = 1 << objectToIgnore1.layer | 1 << objectToIgnore2.layer;

            if (Physics.Raycast(ray, out hit, 100f, ~layerMask))
            {
                GameObject sphere = Instantiate(spherePrefab, hit.point, Quaternion.identity);

                StartCoroutine(PauseCoroutine(sphere));
            }
        }
    }

    IEnumerator PauseCoroutine(GameObject sphere)
    {
        yield return new WaitForSeconds(0.001f);
        Debug.Log("5");
        Destroy(sphere);
    }
}
