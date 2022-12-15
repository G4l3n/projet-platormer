using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGameObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        GetComponent<AudioSource>().Play();
    }
}
