using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireflySpawner : MonoBehaviour
{
    public GameObject firefly;

    void Start()
    {
        FireflySpawn();
    }

    void Update()
    {
        
    }

    public void FireflySpawn()
    {
        GameObject go = Instantiate(firefly, transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180)));
        GameObject go1 = Instantiate(firefly, transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180)));
        GameObject go2 = Instantiate(firefly, transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180)));
        GameObject go3 = Instantiate(firefly, transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180)));
        GameObject go4 = Instantiate(firefly, transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180)));
        GameObject go5 = Instantiate(firefly, transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180)));
    }
}
