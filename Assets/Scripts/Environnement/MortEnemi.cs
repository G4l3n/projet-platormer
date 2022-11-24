using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortEnemi : MonoBehaviour
{
    public float bounceForce = 9f;
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.rb.AddForce(new Vector2(0, bounceForce), ForceMode2D.Impulse);
            Destroy(transform.parent.gameObject);
        }
    }
}
