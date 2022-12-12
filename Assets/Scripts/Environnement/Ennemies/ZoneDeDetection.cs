using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDeDetection : MonoBehaviour
{
    public Collider2D trigger;
    public Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            trigger.transform.GetComponent<Rigidbody2D>().gravityScale = 3;
        }   
    }
}