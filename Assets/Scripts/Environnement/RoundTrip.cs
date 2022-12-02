using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RoundTrip : MonoBehaviour
{
    public Vector2 direction;
    public Vector2 velocity;
    public float speed = 2;

    public Vector2 startPos;
    void Start()
    {
        startPos = transform.position;
        direction = (transform.localRotation * Vector2.right).normalized;
        velocity = direction * speed;
    }

    void Update()
    {
        if (transform.localPosition.x >= startPos.x + 1f || transform.localPosition.x <= startPos.x - 1f)
        {
            velocity = -velocity;
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;
    }
}
