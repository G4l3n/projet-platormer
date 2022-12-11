using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
    [Header("Stalactite")]
    public Collider2D trigger;
    public Collider2D killingCollider;
    public Collider2D walkingCollider;
    public Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            trigger.transform.GetComponent<Rigidbody2D>().gravityScale = 3;
        }   
    }
}