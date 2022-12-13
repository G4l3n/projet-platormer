using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BatOnMove : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D rb = null;
    public Bat bat = null;
    RaycastHit2D hit;
    public LayerMask groundLayer;
    public float fallSpeed = -1f;
    public bool isFalling = false;
    public Vector2 startPos;
    public AnimationCurve acceleration;
    private float t;
    void Start()
    {
        hit = Physics2D.Raycast(transform.position, -Vector2.up, 50f, groundLayer);
        animator = GetComponentInParent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
        startPos = bat.transform.position;
        t = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private void Update()
    {
        if (isFalling)
        {
            var x = bat.transform.position.x;
            var y = Mathf.Lerp(startPos.y, hit.point.y, acceleration.Evaluate(t));
            bat.transform.position = new Vector3(x, y, bat.transform.position.z);
            t += Time.deltaTime / fallSpeed;
        }
    }
    IEnumerator Fall()
    {
        isFalling = true;
        yield return new WaitUntil(() => bat.transform.position.y <= hit.point.y + 2.5f);
        isFalling = false;
        animator.SetBool("IsFlying", true);
    }
}
