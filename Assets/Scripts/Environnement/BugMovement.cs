using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

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

        //Light2D light = player.GetComponentInChildren<Light2D>();
        //Debug.Log(light.GetType);
    }

    void Update()
    {
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
}
