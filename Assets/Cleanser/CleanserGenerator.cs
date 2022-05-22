using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanserGenerator : MonoBehaviour
{
    public GameObject CleanserPrefab;
    public GameObject ARCamera;
    public int speed;

    bool isDelay = false;
    float delayTime = 1f;
    float timer = 0f;

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

    public void Cleanser()
    {
        bool theEnd = CanvasControl.preProcessingEnd;
        ARCamera = GameObject.Find("ARCamera");
        Transform CameraPos = ARCamera.transform;

        if (theEnd && !isDelay)
        {
            GameObject cleanser = Instantiate(CleanserPrefab, CameraPos);
            cleanser.transform.parent = gameObject.transform;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            Vector3 worldDir = ray.direction;
            cleanser.GetComponent<CleanserController>().Shoot(worldDir.normalized * speed);

            isDelay = true;
        }
    }
}
