using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMask : MonoBehaviour
{
    public GameObject humanMaskPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "KF94")
        {
            humanMaskPrefab.SetActive(true);
            /*Debug.Log("¾Ñ! ¸¶½ºÅ©´Ù!");*/
        }
    }
}
