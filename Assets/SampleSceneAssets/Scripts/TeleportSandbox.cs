using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TeleportSandbox : MonoBehaviour
{
    public GameObject Ray;

    void OnTriggerEnter(Collider other)
    {
        Ray.GetComponent<CinemachineDollyCart>().m_Position = 0;
    }


}
