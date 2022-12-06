using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        if (Time.timeSinceLevelLoad > 8f)
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }
}
