using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyMove : MonoBehaviour
{
    public float moveSpeed = 5.8f;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x -= moveSpeed * Time.fixedDeltaTime;

        transform.position = pos;
    }
}
