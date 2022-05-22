using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Rendering/SetRenderQueue")]

/* 마스킹한 오브젝트 가려지도록 하기위한 코드 */

public class SetRenderQueue : MonoBehaviour
{
    [SerializeField]
    protected int[] m_queues = new int[] { 3000 };

    protected void Awake()
    {
        Material[] materials = GetComponent<Renderer>().materials;
        for (int i = 0; i < materials.Length && i < m_queues.Length; ++i)
        {
            materials[i].renderQueue = m_queues[i];
        }

    }
}
