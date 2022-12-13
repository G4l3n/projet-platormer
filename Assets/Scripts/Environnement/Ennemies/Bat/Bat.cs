using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    Animator animator = null;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Test());
    }
    void Update()
    {
        
    }
    IEnumerator Test()
    {
        yield return new WaitForSeconds(3);
        animator.SetBool("IsAwake", true);
        yield return new WaitForSeconds(3);
        animator.SetBool("IsAwake", false);
        yield return new WaitForSeconds(3);
        animator.SetBool("IsAwake", true);
        yield return new WaitForSeconds(3);
        animator.SetBool("IsFlying", true);
        yield return new WaitForSeconds(3);
        Debug.Log("OK");
    }
}
