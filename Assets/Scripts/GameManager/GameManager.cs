using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

// Merci à Youen pour l'aide
public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager Instance { get; private set; }

    [Header("Player")]
    public GameObject player;

    [Header("Kill")]
    public int NbreDeMort;
    public TMP_Text text = null;

    [Header("Light")]
    public Light2D Light2D;
    public float timer;
    public float decrement;
    public float intensity;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
    }
    void Start()
    {
        //http://www.unity3d-france.com/unity/phpBB3/viewtopic.php?t=8741
        //Death count
        NbreDeMort = 0;


        if (PlayerPrefs.GetInt("NbreDeMort") != 0)
        {
            NbreDeMort = PlayerPrefs.GetInt("NbreDeMort");
            text.text = NbreDeMort.ToString();
        }

        //Light intensity
        intensity = Light2D.intensity;
        Pourcentage(timer, intensity);
        if (decrement != 0)
        {
            StartCoroutine(Intensity());
        }
    }
    public void FixedUpdate()
    {
        if (Light2D.intensity <= 0f)
        {
            KillPlayer(player);
        }
    }

    public void KillPlayer(GameObject objectToKill)
    {
        NbreDeMort++;
        PlayerPrefs.SetInt("NbreDeMort", NbreDeMort);
        Destroy(objectToKill);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Pourcentage(float timer, float intensite)
    {
        decrement = (intensite / timer);
    }
    private IEnumerator Intensity()
    {
        yield return new WaitForSeconds(1f);
        Light2D.intensity -= decrement;

        if (Light2D.intensity > 0)
        {
            StartCoroutine(Intensity());
        }
    }
}
