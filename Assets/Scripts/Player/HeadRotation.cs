using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeadRotation : MonoBehaviour
{
    public Player player;
    public GameObject myPlayer;
    public float rotationZ;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // Tuto : https://www.youtube.com/watch?v=6hp9-mslbzI&ab_channel=Nade

    public void OnLook(InputValue lookValue)
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position;

        difference.Normalize();

        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ > 90f || rotationZ < -90f){
            transform.localRotation = Quaternion.Euler(180f, 0f, -rotationZ);
        }
        else{
            transform.localRotation = Quaternion.Euler(0f, 0f, rotationZ);
        }
    }
}


