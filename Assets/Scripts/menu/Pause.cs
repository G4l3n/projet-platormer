using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPause = false;

    private void Start()
    {
        DeactivatepauseMenu();
    }

    bool HaspauseMenu()
    {
        return pauseMenu.activeInHierarchy;
    }
    void ActivatepauseMenu()
    {
        pauseMenu.SetActive(true);
        isPause = true;
        Time.timeScale = 0;
    }
    public void DeactivatepauseMenu()
    {
        pauseMenu.SetActive(false);
        isPause = false;
        Time.timeScale = 1;
    }
    private void OnPause(InputValue PauseValue)
    {
        if (!HaspauseMenu())
        {
            ActivatepauseMenu();   
        }
        else
        {
            DeactivatepauseMenu();          
        }
    }
    //gameobject set active pour le bouton resume
}

