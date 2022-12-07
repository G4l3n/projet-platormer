using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements.Experimental;

public class Player : MonoBehaviour
{
    public Dash Dash;
    public float speed = .0f;
    public bool isReverse { get; private set; }
    new SpriteRenderer renderer = null;
    public Rigidbody2D rb = null;
    Animator animator = null;
    Vector2 movement = Vector2.zero;

    public bool canJump = false;
    public float jumpForce = 9.0f;
    private float originalGravity;

    public GameObject head;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravity = rb.gravityScale;
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Dash == null || !Dash.isDashing)
        {
            rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
        }
        animator.SetBool("IsWalking",movement.x != 0);
        if (movement.x != 0)
        {
            renderer.flipX = movement.x < 0;
            isReverse = movement.x < 0;
        }
    }

    private void FixedUpdate()
    {
        canJump = false;
    }
    public void OnJump(InputValue jumpValue)
    {
        float innerValue = jumpValue.Get<float>();
        if (innerValue > 0 && rb != null && canJump){
            animator.SetBool("IsJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        foreach(ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.9f)
            {
                animator.SetBool("IsJumping", false);
                canJump = true;
            }
            else if (contact.normal.x > 0.9f && collision.gameObject.tag == "Grabbable" 
                     || contact.normal.x < 0.9f && collision.gameObject.tag == "Grabbable")
            {
                animator.SetBool("IsGrabing", true);
                rb.gravityScale = 0.1f;
                canJump = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        rb.gravityScale = originalGravity;
        animator.SetBool("IsGrabing", false);
    }
    public void OnMove(InputValue moveValue)
    { 
        movement = moveValue.Get<Vector2>();
    }
}








