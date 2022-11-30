using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScriptBoue : MonoBehaviour
{
    private Player player;
    private Dash dash;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        dash = GameObject.FindGameObjectWithTag("Player").GetComponent<Dash>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            dash.canDash = false;
            player.JumpForce = 3f;
            player.speed = 3f;
            //Debug.Log("in");
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            dash.canDash = true;
            player.JumpForce = 9f;
            player.speed = 6f;
            //Debug.Log("out");
        }
    }



}
