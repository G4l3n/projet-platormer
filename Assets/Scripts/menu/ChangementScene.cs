using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementScene : MonoBehaviour
{
    public string sceneName = "";

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(sceneName); 
    }
}
