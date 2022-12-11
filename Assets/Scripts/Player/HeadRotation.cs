using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeadRotation : MonoBehaviour
{
    [Header("Player")]
    public Player player;
    public GameObject myPlayer;

    [Header("Head")]
    public float rotationZ;

    [Header("Pause")]
    public Pause Pause;

    //Tuto : https://www.youtube.com/watch?v=6hp9-mslbzI&ab_channel=Nade
    public void OnLook(InputValue lookValue)
    {
        if ( Pause.isPause == false)
        {
            //Head rotation is defined by the position of the mouse in the screen
            Vector3 difference = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position;

            difference.Normalize();

            rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

            //If the mouse passes at the top or the bottom of the player, the head is rotate relative to the horizontal axis
            if (rotationZ > 90f || rotationZ < -90f)
            {
                transform.localRotation = Quaternion.Euler(180f, 0f, -rotationZ);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0f, 0f, rotationZ);
            }
        }
    }
}


