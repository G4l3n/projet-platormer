using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [Header("Pause")]
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
        //AudioSource audioSource = FindObjectOfType<AudioSource>();
        //AudioSource[] audios = AudioSource;

        //foreach (AudioSource audio in audios)
        //{
        //    audio.Pause();
        //}
    }

    public void DeactivatepauseMenu()
    {
        pauseMenu.SetActive(false);
        isPause = false;
        Time.timeScale = 1;
    }
    private void OnPause(InputValue pauseValue)
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

