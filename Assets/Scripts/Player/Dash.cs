using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingCooldown = 1f;
    private float dashingTime = 0.15f;
    private float originalGravity;
    [SerializeField]
    private TrailRenderer tr;
    public bool isReverse;
    Rigidbody2D rb = null;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
    }

    public void OnDash(InputValue dashValue)
    {
        if (canDash)
        {
            if (isReverse)
            {
                dashingPower = -dashingPower;
                StartCoroutine(Dashing());
                dashingPower = -dashingPower;
            }
            else
            {
                StartCoroutine(Dashing());
            }
        }
    }


    public IEnumerator Dashing()
    {
        canDash = false;
        isDashing = true;

        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    //https://www.youtube.com/watch?v=2kFGmuPHiA0 : dash
}
