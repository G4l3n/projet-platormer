using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        if (Time.timeSinceLevelLoad > 7.5f)
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }
}
