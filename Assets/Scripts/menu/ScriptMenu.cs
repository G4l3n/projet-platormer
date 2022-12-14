using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour
{

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Credits()
    {
        
        SceneManager.LoadScene("credits");

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
   
   


    public void Update()
    {
        

    }
}
