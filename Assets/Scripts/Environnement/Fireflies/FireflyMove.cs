using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyMove : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (transform.position.x > player.transform.position.x && transform.position.x - player.transform.position.x > 15
            || transform.position.x < player.transform.position.x && player.transform.position.x - transform.position.x > 15
            || transform.position.y > player.transform.position.y && transform.position.y - player.transform.position.y > 15
            || transform.position.y < player.transform.position.y && player.transform.position.y - transform.position.y > 15)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        float x = moveSpeed * Time.fixedDeltaTime;

        float y = Mathf.Sin(Time.realtimeSinceStartup * 6) * 0.1f;
        Vector2 direction = new Vector2(transform.up.x, transform.up.y);

        Vector2 delta = direction * x + y * -Vector2.Perpendicular(direction);

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
