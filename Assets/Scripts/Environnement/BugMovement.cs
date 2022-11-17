using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Vector3 startPos;
    new SpriteRenderer renderer = null;

    private Player player;

    void Start()
    {
        startPos = transform.position;
        renderer = GetComponent<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (startPos.x > player.transform.position.x)
        {
            renderer.flipX = true;
            moveSpeed = -moveSpeed;
        }
    }

    void Update()
    {
        Vector2 pos = transform.position;

        pos.x += moveSpeed * Time.deltaTime;

        transform.position = pos;
    }
}
