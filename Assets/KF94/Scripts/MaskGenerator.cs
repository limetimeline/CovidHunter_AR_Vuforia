using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskGenerator : MonoBehaviour
{
    public GameObject MaskPrefab;
    public GameObject ARCamera;
    public int speed;


    bool isDelay = false;
    float delayTime = 1f;
    float timer = 0f;

    void Start()
    {
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

    public void MaskGen()
    {
        bool theEnd = CanvasControl.preProcessingEnd;
        ARCamera = GameObject.Find("ARCamera");
        Transform CameraPos = ARCamera.transform;

        if (theEnd && !isDelay)
        {
            GameObject mask = Instantiate(MaskPrefab, CameraPos);
            /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);*/
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            Vector3 worldDir = ray.direction;
            mask.GetComponent<MaskController>().Shoot(worldDir.normalized * speed);
            isDelay = true;
        }
    }
}
