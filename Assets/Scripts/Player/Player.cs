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
    private float dashingCooldown = 1f;
    private float dashingTime = 0.15f;
    private float originalGravity;
    [SerializeField] private TrailRenderer tr;

    public float speed = .0f;
    public bool isReverse;
    new SpriteRenderer renderer = null;
    Rigidbody2D rb = null;
    Animator animator = null;
    Vector2 movement = Vector2.zero;

    int MaxNumberOfJumps = 1;
    public int NumberOfJumps = 0;
    public float JumpForce = 9.0f;

    public HeadRotation headRotation;
    public GameObject head;

    void Start(){      
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        originalGravity = rb.gravityScale;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDashing){
            return;
        }

        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
        animator.SetBool("IsWalking",movement.x != 0);
        if (movement.x != 0)
        {
            renderer.flipX = movement.x < 0;
            isReverse = movement.x < 0;
        }
    }

    public void OnDash(InputValue dashValue){
        if (canDash){
            if (isReverse){
                dashingPower = -dashingPower;
                StartCoroutine(Dash());
                dashingPower = -dashingPower;
            }
            else{
                StartCoroutine(Dash());
            }
        }
    }

    public void OnJump(InputValue jumpValue){

        float innerValue = jumpValue.Get<float>();
        if (innerValue > 0 && rb != null && NumberOfJumps > 0){
            animator.SetBool("IsJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            NumberOfJumps--;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.GetContact(0).normal.x > -0.5f){
            animator.SetBool("IsJumping", false);
            NumberOfJumps = MaxNumberOfJumps;
        }
    }
    public void OnMove(InputValue moveValue){
        movement = moveValue.Get<Vector2>();
    }

    //https://www.youtube.com/watch?v=2kFGmuPHiA0 : dash

    private IEnumerator Dash(){
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
}








