using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleGenerator : MonoBehaviour
{
    public GameObject[] people;
    public Transform[] instantCubePos;

    float span = 3.0f;
    float delta = 0;

    int startPin = 0;


    void Update()
    {
        bool theEnd = CanvasControl.preProcessingEnd;
        this.delta += Time.deltaTime;
        if ((this.delta > this.span) && theEnd)
        {
            this.delta = 0;
            GameObject instantPeople = Instantiate(people[Random.Range(0, 8)]);
            /*GameObject instantPeople = Instantiate(people[7]);*/
            instantPeople.transform.parent = gameObject.transform;
            WayPointMove peopleMove = instantPeople.GetComponent<WayPointMove>();

            startPin = Random.Range(0, 8); // 9°³ÀÇ ÇÉ Áß ½ÃÀÛÇÒ ÇÉÀ» »ÌÀ½
            peopleMove.cubePos[0] = instantCubePos[startPin]; // ½ÃÀÛ ÇÉ ÁöÁ¤

            switch (startPin)
            {
                case 0: // 1 -> 2 -> 3 -> 4 -> 5
                    peopleMove.cubePos[1] = instantCubePos[1];
                    peopleMove.cubePos[2] = instantCubePos[2];
                    peopleMove.cubePos[3] = instantCubePos[3];
                    peopleMove.cubePos[4] = instantCubePos[4];
                    break;
                case 1: // 2 -> 8 -> 9 -> 1 -> 2
                    peopleMove.cubePos[1] = instantCubePos[7];
                    peopleMove.cubePos[2] = instantCubePos[8];
                    peopleMove.cubePos[3] = instantCubePos[0];
                    peopleMove.cubePos[4] = instantCubePos[1];
                    break;
                case 2: // 3 -> 4 -> 5 -> 6 -> 7
                    peopleMove.cubePos[1] = instantCubePos[3];
                    peopleMove.cubePos[2] = instantCubePos[4];
                    peopleMove.cubePos[3] = instantCubePos[5];
                    peopleMove.cubePos[4] = instantCubePos[6];
                    break;
                case 3: // 4 -> 3 -> 2 -> 8 -> 9
                    peopleMove.cubePos[1] = instantCubePos[2];
                    peopleMove.cubePos[2] = instantCubePos[1];
                    peopleMove.cubePos[3] = instantCubePos[7];
                    peopleMove.cubePos[4] = instantCubePos[8];
                    break;
                case 4: // 5 -> 6 -> 7 -> 8 -> 3
                    peopleMove.cubePos[1] = instantCubePos[5];
                    peopleMove.cubePos[2] = instantCubePos[6];
                    peopleMove.cubePos[3] = instantCubePos[7];
                    peopleMove.cubePos[4] = instantCubePos[2];
                    break;
                case 5: // 6 -> 5 -> 4 -> 3 -> 8
                    peopleMove.cubePos[1] = instantCubePos[4];
                    peopleMove.cubePos[2] = instantCubePos[3];
                    peopleMove.cubePos[3] = instantCubePos[2];
                    peopleMove.cubePos[4] = instantCubePos[7];
                    break;
                case 6: // 7 -> 8 -> 2 -> 3 -> 4
                    peopleMove.cubePos[1] = instantCubePos[7];
                    peopleMove.cubePos[2] = instantCubePos[1];
                    peopleMove.cubePos[3] = instantCubePos[2];
                    peopleMove.cubePos[4] = instantCubePos[3];
                    break;
                case 7: // 8 -> 2 -> 1 -> 9 -> 8
                    peopleMove.cubePos[1] = instantCubePos[1];
                    peopleMove.cubePos[2] = instantCubePos[0];
                    peopleMove.cubePos[3] = instantCubePos[8];
                    peopleMove.cubePos[4] = instantCubePos[7];
                    break;
                case 8: // 9 -> 8 -> 7 -> 6 -> 5
                    peopleMove.cubePos[1] = instantCubePos[7];
                    peopleMove.cubePos[2] = instantCubePos[6];
                    peopleMove.cubePos[3] = instantCubePos[5];
                    peopleMove.cubePos[4] = instantCubePos[4];
                    break;
                default:
                    break;
            }

            this.span = Random.Range(3, 8);
        }
    }
}
