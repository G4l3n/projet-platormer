using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [Header("Pause")]
    public GameObject pauseMenu;
    [SerializeField] private AudioSource[] Audio;
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
        AudioListener.pause = true;
    }

    public void DeactivatepauseMenu()
    {
        pauseMenu.SetActive(false);
        isPause = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
        //foreach (AudioSource audio in Audio)
        //{
        //    audio.Play();
        //}
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

