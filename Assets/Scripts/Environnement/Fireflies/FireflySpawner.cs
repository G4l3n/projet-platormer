using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireflySpawner : MonoBehaviour
{
    [Header("Spawner")]
    private bool canSpawn = true;
    public float dispawnTime = 5f;

    [Header("Object to spawn")]
    public GameObject firefly;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canSpawn)
        {
            if (other.gameObject.tag == "Player")
            {
                FireflySpawn();
            }
        }
    }

    //Spawn 6 fireflies in any direction
    public void FireflySpawn()
    {
        GameObject go = Instantiate(firefly, transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180)));
        GameObject go1 = Instantiate(firefly, transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180)));
        GameObject go2 = Instantiate(firefly, transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180)));
        GameObject go3 = Instantiate(firefly, transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180)));
        GameObject go4 = Instantiate(firefly, transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180)));
        GameObject go5 = Instantiate(firefly, transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180)));
        StartCoroutine(Dispawn());
    }

    //Dispawn during a definite time
    public IEnumerator Dispawn()
    {
        canSpawn = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(dispawnTime);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        canSpawn = true;
    }
}
