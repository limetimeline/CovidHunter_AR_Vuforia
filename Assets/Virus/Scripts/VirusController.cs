using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{
    float virusDestoryTime = 10.0f;
    public VirusGenerator currentGen;

    void Start()
    {
        currentGen.exist = true;
        Debug.Log("바이러스 나타남" + currentGen.exist);
    }

    void Update()
    {
        bool theEnd = CanvasControl.preProcessingEnd;

        if (!theEnd)
        {
            /*Destroy(gameObject);*/
        }
        else
        {
            Destroy(gameObject, virusDestoryTime);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Cleanser")
        {
            Debug.Log("소독제에 의해");
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        currentGen.exist = false;
        currentGen.delta = 0;
        Debug.Log("바이러스 사라짐" + currentGen.exist);
    }
}
