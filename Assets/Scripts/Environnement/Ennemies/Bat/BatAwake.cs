using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAwake : MonoBehaviour
{
    Animator animator = null;
    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("enter");
            animator.SetBool("IsAwake", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("enter");
            animator.SetBool("IsAwake", false);
        }
    }
}
