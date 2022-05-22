using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskController : MonoBehaviour
{
    public float destroyTime = 1.0f;

    void Update()
    {
        Destroy(gameObject, destroyTime); // 마스크가 destroyTime 후 제거
    }

    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    void OnTriggerEnter(Collider other)
    {
        /* 마스크가 사람이나 벽에 닿으면 파괴 */
        if (other.gameObject.tag == "Human" || other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
