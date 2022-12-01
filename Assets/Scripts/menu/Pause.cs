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
        Time.timeScale = 0;
    }
    void DeactivatepauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    private void OnPause(InputValue PauseValue)
    {
        if (!HaspauseMenu())
        {
            ActivatepauseMenu();
            isPause = true;
        }
        else
        {
            DeactivatepauseMenu();
            isPause = false;   
        }
    }
}

