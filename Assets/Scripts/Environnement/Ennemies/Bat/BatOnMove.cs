using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BatOnMove : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D rb = null;
    RaycastHit2D hit;
    public LayerMask groundLayer;
    void Start()
    {
        hit = Physics2D.Raycast(transform.position, -Vector2.up, 50f, groundLayer);
        animator = GetComponentInParent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        rb.gravityScale = 2f;
        yield return transform.position.y == hit.point.y + 3;
        animator.SetBool("IsFlying", true);
    }
}
