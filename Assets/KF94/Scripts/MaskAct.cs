using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskAct : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Human")
        {
           /* Debug.Log("사람을 맞췄다!");*/
        }
    }
}
