using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDeDetection : MonoBehaviour
{

    public GameObject zone;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        zone.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }


}
