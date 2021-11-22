using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{

    private GameObject ray;
    public GameObject target;

    private void Awake() 
    {
        ray = transform.GetChild(0).gameObject;
        target = ray.transform.GetChild(0).gameObject;
    }

    public void Shooting(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("Piou");
            Debug.DrawRay(ray.transform.position, target.transform.position);
        }
    }
}
