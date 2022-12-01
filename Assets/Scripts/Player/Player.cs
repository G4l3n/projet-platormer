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

    int MaxNumberOfJumps = 1;
    public int NumberOfJumps = 0;
    public float JumpForce = 9.0f;

    public GameObject head;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    public void OnJump(InputValue jumpValue)
    {
        float innerValue = jumpValue.Get<float>();
        if (innerValue > 0 && rb != null && NumberOfJumps > 0){
            animator.SetBool("IsJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            NumberOfJumps--;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.GetContact(0).normal.y > 0.9f){
            animator.SetBool("IsJumping", false);
            NumberOfJumps = MaxNumberOfJumps;
        }
    }
    public void OnMove(InputValue moveValue)
    { 
        movement = moveValue.Get<Vector2>();
    }
}








