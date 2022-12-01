using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DontDestroyOnLoad : MonoBehaviour
{
    public Camera cam;
    private LightInMenu Script;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(cam);
        DontDestroyOnLoad(Script);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
