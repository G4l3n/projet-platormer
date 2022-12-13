using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BatFall : MonoBehaviour
{
    [Header("Bat")]
    public Bat bat = null;
    Animator animator = null;

    [Header("Fall")]
    RaycastHit2D hit;
    public LayerMask groundLayer;
    public float fallSpeed = 1f;
    private float t;
    public AnimationCurve acceleration;
    public bool isFalling = false;
    void Start()
    {
        hit = Physics2D.Raycast(transform.position, -Vector2.up, 50f, groundLayer);
        t = 0;
        animator = GetComponentInParent<Animator>();
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
            animator.SetBool("IsFalled", true);
            var x = bat.startPos.x;
            var y = Mathf.Lerp(bat.startPos.y, hit.point.y + 1f, acceleration.Evaluate(t));
            bat.transform.position = new Vector3(x, y, bat.startPos.z);
            t += Time.deltaTime / fallSpeed;
        }
    }
    IEnumerator Fall()
    {
        isFalling = true;
        yield return new WaitUntil(() => bat.transform.position.y <= hit.point.y + 1f);
        isFalling = false;
        animator.SetBool("IsFlying", true);
        bat.isFlying = true;
    }
}