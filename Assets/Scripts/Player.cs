using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public float speed = .0f;
    Rigidbody2D rb = null;
    Vector2 movement = Vector2.zero;
    int MaxNumberOfJumps = 2;
    public int NumberOfJumps = 0;
    public float JumpForce = 9.0f;
    SpriteRenderer renderer = null;
    //Animator animator = null;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(movement.x*speed, rb.velocity.y);
        //animator.SetBool("IsWalking",movement.x != 0);
        if (movement.x != 0)
        {
            renderer.flipX = movement.x < 0;
        }
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
        if (collision.GetContact(0).normal.y > -0.5f)
        {
            NumberOfJumps = MaxNumberOfJumps;
        }
    }
    public void OnMove(InputValue moveValue)
    {
        movement = moveValue.Get<Vector2>();
    }
}

