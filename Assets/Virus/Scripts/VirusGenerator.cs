using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusGenerator : MonoBehaviour
{
    public GameObject VirusPrefab; // 바이러스 프리펩
    public float span = 0; // 생성 간격
    public float delta = 0; // 델타타임 (동기화)
    
    public bool exist = false; // 바이러스 존재 여부

    void Start()
    {

        
    }

    void Update()
    {
        bool theEnd = CanvasControl.preProcessingEnd;

        var render = gameObject.GetComponents<Renderer>();

        foreach (var component in render)
            component.enabled = false;

        this.delta += Time.deltaTime;

        if (!theEnd)
        {
            this.delta = 0;
            this.exist = false;
        }

        if (span == 0)
        {
            this.span = Random.Range(3, 15);
        }

        if (this.delta > this.span && exist == false && theEnd)
        {
            GameObject instantVirus = Instantiate(VirusPrefab);
            instantVirus.transform.parent = gameObject.transform;
            instantVirus.transform.position = gameObject.transform.position;

            VirusController currentVirus = instantVirus.GetComponent<VirusController>();
            currentVirus.currentGen = gameObject.GetComponent<VirusGenerator>();
            

            this.span = Random.Range(1, 10);
        }
    }

    /*void OnTriggerStay(Collider other)
    {
        *//*if (other.tag == "Virus")
        {
            this.exist = true;
            this.delta = 0;
        }*/
     /*   else
        {
                this.exist = false;
                this.delta = 0;
                Debug.Log("바이러스가 사라졌다.");
        }*//*
    }

*//*    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Virus")
        {
            this.exist = false;
            this.delta = 0;
            Debug.Log("바이러스가 사라졌다.");
        }
    }*/
}
