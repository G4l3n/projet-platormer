using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Kill : MonoBehaviour
{

    public int NbreDeMort;

    // Start is called before the first frame update
    void Start()
    {
       
        if (PlayerPrefs.GetInt("NbreDeMort") != 0)
        {
            NbreDeMort = PlayerPrefs.GetInt("NbreDeMort");

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
            Debug.Log(NbreDeMort);
            Destroy(other.gameObject);
            SceneManager.LoadScene("Manon");
        } 
    }
}
