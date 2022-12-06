using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RoundTrip : MonoBehaviour
{
    public Vector2 direction;
    public Vector2 velocity;
    public float speed = 0f;

    public Vector2 startPos;
    void Start()
    {
        startPos = transform.localPosition;
        direction = (transform.localRotation * Vector2.right).normalized;
        velocity = direction * speed;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;

        if (transform.localPosition.x > 0 && transform.localPosition.x > startPos.x + 0.5f
            || transform.localPosition.x < 0 && transform.localPosition.x < startPos.x - 0.5f)
        {
            velocity = -velocity;
        }
    }
}
