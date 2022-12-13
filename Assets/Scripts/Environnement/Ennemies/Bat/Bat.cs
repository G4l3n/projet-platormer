using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [Header("Bat")]
    public Vector3 startPos;

    [Header("Player")]
    private Player player;
    public float bounceForce = 9f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        startPos = transform.position;
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
