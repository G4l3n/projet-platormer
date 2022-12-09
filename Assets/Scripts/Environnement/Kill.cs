using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class Kill : MonoBehaviour
{
    public int NbreDeMort;
    public TMP_Text text = null;

    // http://www.unity3d-france.com/unity/phpBB3/viewtopic.php?t=8741 pour le nbre de mort
    void Start()
    {

        NbreDeMort = 0;
        

        if (PlayerPrefs.GetInt("NbreDeMort") != 0)
        {
            NbreDeMort = PlayerPrefs.GetInt("NbreDeMort");
            text.text = NbreDeMort.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            NbreDeMort++;
            PlayerPrefs.SetInt("NbreDeMort", NbreDeMort);
            Death(other.gameObject);
        } 
    }
    public void Death(GameObject player)
    {
        Destroy(player);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
