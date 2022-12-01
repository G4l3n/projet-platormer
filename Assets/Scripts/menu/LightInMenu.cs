using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class LightInMenu : MonoBehaviour
{
    public GameObject Light;
    Vector3 posMouse;


    public void Update()
    {
        Light.transform.GetComponent<Camera>().enabled = true;
    }

    public void FixedUpdate()
    {
        posMouse = Input.mousePosition;
        Vector3 pos = Camera.main.ScreenToWorldPoint(posMouse);
        pos.z = 0;
        transform.position = pos;
    }

    



}
