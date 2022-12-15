using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [Header("Bat")]
    public Vector3 startPos;
    public float moveSpeed;
    new SpriteRenderer renderer = null;
    public bool isFlying = false;
    public float range;

    [Header("Player")]
    private Player player;
    public float bounceForce = 9f;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        startPos = transform.position;
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isFlying)
        {
            var x = transform.position.x;
            var y = transform.position.y;

            transform.position = new Vector3(x + moveSpeed * Time.deltaTime, y, startPos.z);

            if (transform.position.x >= startPos.x + range || transform.position.x <= startPos.x - range)
            {
                moveSpeed = -moveSpeed;
                if (transform.position.x >= startPos.x)
                {
                    renderer.flipX = true;
                }
                else
                {
                    renderer.flipX = false;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (contact.normal.y < 0)
                {
                    player.rb.AddForce(new Vector2(0, bounceForce), ForceMode2D.Impulse);
                    Destroy(this.gameObject);
                }
                else
                {
                    GameManager.Instance.KillPlayer(player.gameObject);
                }
            }
        }
    }
}
