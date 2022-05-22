using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMove : MonoBehaviour
{
    public Transform target;
    public Transform[] cubePos;
    /*public Transform[] instantCubePos;*/

    float speed = 0.1f; // 인간 이동 속도
    /*    float r_speed = 2f;*/
    int count = 0;
    int cubeNum = 0;


    void Start()
    {
        transform.position = cubePos[cubeNum].transform.position; // Generator에서 지정해준 시작 핀 위치
    }

    void FixedUpdate()
    {
        if (cubeNum == cubePos.Length)
        {
            Destroy(gameObject);
        }
        else
        {
            MovePath();
            RotateMove();
        }
    }

    public void MovePath()
    {
        transform.position = Vector3.MoveTowards(transform.position, cubePos[cubeNum].transform.position, speed * Time.deltaTime);
        target = cubePos[cubeNum];

        if (transform.position == cubePos[cubeNum].transform.position)
        {
            cubeNum++;
        }

        /*if (cubeNum == cubePos.Length)
        {
            cubeNum = 0;
        }*/
    }

    public void RotateMove()
    {
        Vector3 dir = target.position - transform.position;

        dir.y = 0f;

        if (dir != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(dir.normalized);

            transform.rotation = rot;
        }
    }

}
