using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Vector3 startPos;
    new SpriteRenderer renderer = null;

    void Start()
    {
        startPos = transform.position;
        renderer = GetComponent<SpriteRenderer>();
        
        Player player = GetComponent<Player>();
        Debug.Log(player.transform.position.x);
    }

    void Update()
    {
        Vector2 pos = transform.position;

        pos.x -= moveSpeed * Time.deltaTime;

        transform.position = pos;
    }
}
