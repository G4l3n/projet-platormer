using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mud : MonoBehaviour
{
    [Header("Player")]
    private Player player;
    private Dash dash;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        dash = GameObject.FindGameObjectWithTag("Player").GetComponent<Dash>();
    }

    //If the player is in the mud, he moves slowly and can't dash
    private void OnTriggerStay2D(Collider2D other)
    {   
        if (other.gameObject.tag == "Player")
        {
            dash.canDash = false;
            player.jumpForce = 3f;
            player.speed = 3f;
        }       
    }

    //Player goes out
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            dash.canDash = true;
            player.jumpForce = 9f;
            player.speed = 6f;
        }
    }
}
