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

    public void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        difference.Normalize();

        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ > 50f && rotationZ < 90f && !player.isReverse){
            transform.rotation = Quaternion.Euler(0f, 0f, 50f);
        }
        else if (rotationZ < 130f && rotationZ > 90f && player.isReverse){
            transform.rotation = Quaternion.Euler(0f, 0f, 130f);
        }
        else if (rotationZ < -40f && rotationZ > -90f && !player.isReverse){
            transform.rotation = Quaternion.Euler(0f, 0f, -40f);
        }
        else if (rotationZ > -140f && rotationZ < -90f && player.isReverse){
            transform.rotation = Quaternion.Euler(0f, 0f, -140f);
        }
    }
}


