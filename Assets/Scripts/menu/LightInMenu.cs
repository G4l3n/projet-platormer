using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class LightInMenu : MonoBehaviour
{
    [Header("Light")]
    public GameObject Light;

    public void Update()
    {
        //The torch follows the mouse on the screen
        Light.transform.GetComponent<Camera>().enabled = true;

        Vector3 pos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        pos.z = 0;
        transform.position = pos;
    }
}
