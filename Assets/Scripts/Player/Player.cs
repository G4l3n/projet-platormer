using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements.Experimental;

public class Player : MonoBehaviour
{
    [Header("Head")]
    public GameObject head;

    [Header("Movement")]
    public bool isMoving = false;
    public float speed = 0f;
    Vector2 movement = Vector2.zero;

    [Header("Jump")]
    public Rigidbody2D rb = null;
    public bool canJump = false;
    public float jumpForce = 9.0f;
    private float originalGravity;
    public float rayLenght =1;

    [Header("Dash")]
    public Dash Dash;

    [Header("Wall Jump")]
    public LayerMask groundLayer;
    public bool isGrounded = false;
    public float wallJumpTime = 0.2f;
    public float wallSlideSpeed = 0.3f;
    public float wallDistance = 0.5f;
    public bool isWallSliding = false;
    RaycastHit2D wallCheckHit;
    private float jumpTime;

    [Header("Sprite")]
    new SpriteRenderer renderer = null;
    Animator animator = null;
    public bool isReverse { get; private set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravity = rb.gravityScale;
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if ((Dash == null || !Dash.isDashing))
        {
            rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
        }
        animator.SetBool("IsWalking",movement.x != 0);
        if (movement.x != 0)
        {
            renderer.flipX = movement.x < 0;
            isReverse = movement.x < 0;;
        }
    }

    private void FixedUpdate()
    {
        canJump = Physics2D.Raycast(transform.position, -transform.up.normalized, rayLenght, groundLayer).collider != null;
        isGrounded = canJump;
        animator.SetBool("IsJumping", !canJump);

        // Wall Jump

        if (!isReverse)
        {
            wallCheckHit = Physics2D.Raycast(transform.position, new Vector2(wallDistance, 0), wallDistance, groundLayer);
            Debug.DrawRay(transform.position, new Vector2(wallDistance, 0), Color.green);
        }
        else
        {
            wallCheckHit = Physics2D.Raycast(transform.position, new Vector2(-wallDistance, 0), wallDistance, groundLayer);
            Debug.DrawRay(transform.position, new Vector2(-wallDistance, 0), Color.green);
        }

        if (wallCheckHit && !isGrounded && isMoving)
        {
            isWallSliding = true;
            jumpTime = Time.time + wallJumpTime;
        }
        else if (jumpTime < Time.time)
        {
            isWallSliding = false;
        }

        if (isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, wallSlideSpeed, float.MaxValue));
        }
    }
    public void OnJump(InputValue jumpValue)
    {
        float innerValue = jumpValue.Get<float>();
        if (innerValue > 0 && rb != null && canJump)
        {
            isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
    public void OnMove(InputValue moveValue)
    {
        movement = moveValue.Get<Vector2>();
        isMoving = true;
        //if (movement == Vector2.zero)
        //{
        //    Debug.Log("stop");
        //    GetComponent<AudioSource>().Stop();
        //}
        //else
        //{
        //    Debug.Log("play");
        //    GetComponent<AudioSource>().Play();
        //}
        
    }
}
