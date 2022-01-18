using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{

    private GameObject ray;
    private GameObject nug;
    private GameObject target;
    public GameObject bullet;


    private void Awake() 
    {
        ray = transform.GetChild(0).gameObject;
        nug = ray.transform.GetChild(5).gameObject;
        target = ray.transform.GetChild(0).gameObject;
    }
    private void Start() 
    {
        
    }

    public void Shooting(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Vector3 dir = target.transform.position - nug.transform.position;
            Quaternion bulletRotation = Quaternion.LookRotation(dir, nug.transform.InverseTransformDirection(nug.transform.up));
            Instantiate(bullet, nug.transform.position, bulletRotation, gameObject.transform);
        }
    }
}

