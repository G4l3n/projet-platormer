using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDeDetection : MonoBehaviour
{

    public Collider2D zone;
    public Rigidbody2D body;
    


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
        if(other.gameObject.tag == "Player")
        {
            zone.transform.GetComponent<Rigidbody2D>().gravityScale = 3;
        }
       
    }


}
