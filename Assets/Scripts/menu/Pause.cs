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
    Animator animator;

    private void Start()
    {
        DeactivatepauseMenu();
        animator = GetComponent<Animator>();
    }

    bool HaspauseMenu()
    {
        return pauseMenu.activeInHierarchy;
    }
    void ActivatepauseMenu()
    {
        pauseMenu.SetActive(true);
        animator?.Play("AnimationLight");
        isPause = true;
        Time.timeScale = 0;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audio in audios)
        {
            audio.Pause();
        }
    }

    public void DeactivatepauseMenu()
    {
        pauseMenu.SetActive(false);
        isPause = false;
        Time.timeScale = 1;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audio in audios)
        {
            audio.Play();
        }
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

