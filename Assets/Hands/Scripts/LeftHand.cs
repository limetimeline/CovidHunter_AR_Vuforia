using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHand : MonoBehaviour
{
    public Animator anim;
    bool isDelay = false;
    float delayTime = 1f;
    float timer = 0f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDelay)
        {
            timer += Time.deltaTime;
            if (timer >= delayTime)
            {

                timer = 0f;
                isDelay = false;
            }
        }
    }

    public void Throw() {
        bool theEnd = CanvasControl.preProcessingEnd;
        if (!isDelay && theEnd)
        {
            anim.SetTrigger("Spray");
            isDelay = true;
        }
        
        
    }
}
