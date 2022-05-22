using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanserController : MonoBehaviour
{
    public float destroyTime = 1.0f;
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyTime);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Virus")
        {
            Destroy(gameObject);
        }
    }
}
