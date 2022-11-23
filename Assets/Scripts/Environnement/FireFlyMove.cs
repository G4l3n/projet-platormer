using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyMove : MonoBehaviour
{
    public float moveSpeed = 5.8f;
    float sinCenterY;
    public Vector2 direction;
    void Start()
    {
        sinCenterY = transform.position.y;
        direction.Normalize();
    }

    private void FixedUpdate()
    {
        float x = moveSpeed * Time.fixedDeltaTime;

        float y = Mathf.Sin(Time.realtimeSinceStartup * 6) * 0.1f;

        Vector2 delta = direction * x + y * -Vector2.Perpendicular(direction);

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
