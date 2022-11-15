using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.15f;
    private float dashingCooldown = 5f;

    public float speed = .0f; 
    int MaxNumberOfJumps = 1;
    public int NumberOfJumps = 0;
    public float JumpForce = 9.0f;
    new SpriteRenderer renderer = null;
    public HeadRotation headRotation;
    public GameObject head;
    public bool isReverse;

    Rigidbody2D rb = null;
    //Animator animator = null;
    Vector2 movement = Vector2.zero;
    [SerializeField] private TrailRenderer tr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
        //animator.SetBool("IsWalking",movement.x != 0);
        if (movement.x != 0)
        {
            renderer.flipX = movement.x < 0;
            isReverse = true;
        }
    }

    public void OnDash(InputValue dashValue)
    {
        StartCoroutine(Dash());
    }

    public void OnJump(InputValue jumpValue)
    {

        float innerValue = jumpValue.Get<float>();
        if (innerValue > 0 && rb != null && NumberOfJumps > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            NumberOfJumps--;
            //animator.SetTrigger("HasJumped");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.GetContact(0).normal.x > -0.5f)
        {
            NumberOfJumps = MaxNumberOfJumps;
        }
    }
    public void OnMove(InputValue moveValue)
    {
        if (isDashing)
        {
            return;
        }

        movement = moveValue.Get<Vector2>();
    }

    //https://www.youtube.com/watch?v=2kFGmuPHiA0 : dash

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
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
}








