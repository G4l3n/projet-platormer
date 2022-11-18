using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMenu : MonoBehaviour
{
    public GameObject Button;

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void Update()
    {
        

    }
}
