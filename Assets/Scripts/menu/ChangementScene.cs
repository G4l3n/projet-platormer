using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementScene : MonoBehaviour
{
    Animator transitionlvl;


    public void Start()
    {
        transitionlvl = GetComponent<Animator>();
        
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        transitionlvl.SetTrigger("fadein");
        Changement();
    }

    public void Changement()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
