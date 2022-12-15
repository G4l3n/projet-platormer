using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;


public class BugMovement : MonoBehaviour
{
    [Header("Bug")]
    private Vector3 startPos;
    public float moveSpeed = 1f;
    public float bounceForce = 9f;
    new SpriteRenderer renderer = null;

    [Header("Player")]
    private Player player;

    void Start()
    {
        startPos = transform.position;
        renderer = GetComponent<SpriteRenderer>();
        GetComponent<AudioSource>().Play();

        //Bug walk forward in the direction of the player at his start position
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (transform.position.x > player.transform.position.x)
        {
            renderer.flipX = true;
            moveSpeed = - Mathf.Abs(moveSpeed);
        }
        else
        {
            renderer.flipX = false;
            moveSpeed = Mathf.Abs(moveSpeed);
        }
        // check if the bug is outside of the player vision
        if (transform.position.x > player.transform.position.x && transform.position.x - player.transform.position.x > 15
            || transform.position.x < player.transform.position.x && player.transform.position.x - transform.position.x > 15
            || transform.position.y > player.transform.position.y && transform.position.y - player.transform.position.y > 15
            || transform.position.y < player.transform.position.y && player.transform.position.y - transform.position.y > 15)
        {
            Destroy(gameObject);
        }

        var x = transform.position.x;
        var y = transform.position.y; 

        transform.position = new Vector3(x + moveSpeed * Time.deltaTime, y, startPos.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                //If the player is hit by the bug, we kill the player
                if (contact.normal.x != 0 && contact.normal.y == 0)
                {
                    GameManager.Instance.KillPlayer(player.gameObject);
                }
                
                //If the player jump on the bug, he bounce on him and the bug is killed
                else if  (contact.normal.y != 0)
                {
                    player.rb.AddForce(new Vector2(0, bounceForce), ForceMode2D.Impulse);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
