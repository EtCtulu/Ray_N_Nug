using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSandbox : MonoBehaviour
{
    public GameObject teleportPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TeleportSandbox")
        {
            other.gameObject.transform.position = teleportPoint.transform.position;
        }

    }


}
