using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPanel : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        bool theEnd = CanvasControl.preProcessingEnd;
        if (theEnd)
        {
            gameObject.SetActive(true);
        }
    }
}
