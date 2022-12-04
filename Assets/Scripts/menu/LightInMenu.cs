using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class LightInMenu : MonoBehaviour
{
    public GameObject Light;


    public void Update()
    {
        Light.transform.GetComponent<Camera>().enabled = true;

        Vector3 pos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        pos.z = 0;
        transform.position = pos;

    }

    public void FixedUpdate()
    {
      
    }

    



}
