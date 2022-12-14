using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerBug : MonoBehaviour
{
    [Header("Spawner")]
    private bool canSpawn = true;
    private float dispawnTime = 5f;

    [Header("Object to spawn")]
    public GameObject Bug;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canSpawn)
        {
            if (other.gameObject.tag == "Player")
            {
                BugSpawn();
            }
        }
    }
    public void BugSpawn()
    {
        GameObject go = Instantiate(Bug, transform.position, Quaternion.identity);
        StartCoroutine(Dispawn());
    }

    public IEnumerator Dispawn()
    {
        canSpawn = false;
        yield return new WaitForSeconds(dispawnTime);
        canSpawn = true;
    }
    
}
