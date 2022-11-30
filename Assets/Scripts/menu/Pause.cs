using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class echap : MonoBehaviour
{
    public GameObject pauseMenu;

    private void Start()
    {
        DeactivatepauseMenu();
    }

    bool HaspauseMenu()
    {
        return pauseMenu.activeSelf;
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

    public void Update()
    {
        if (!HaspauseMenu())
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                ActivatepauseMenu();

            }

        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                DeactivatepauseMenu();
            }
        }
    }
}
