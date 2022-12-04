using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DontDestroyOnLoad : MonoBehaviour
{
    public Light2D Light;
    

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(Light);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
