using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visor : MonoBehaviour
{

    private Transform uiCam;

    // Start is called before the first frame update
    void Start()
    {
        uiCam = Camera.main.transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(uiCam);
    }
}
