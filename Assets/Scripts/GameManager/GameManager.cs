using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

// Merci à Youen pour l'aide
public class GameManager : MonoBehaviour
{
    //Singleton
    private static GameManager _instance = null;
    private GameManager() { }
    public static GameManager Instance => _instance;

    [Header("Player")]
    private Player player;
    public float timer;

    [Header("Kill")]
    public int DeathNumber;
    public TMP_Text DeathCount = null;
    public Image dashPicto = null;

    [Header("Light")]
    private Light2D playerLight;
    public float lightDecrement;

    [Header("Sound")]
    private AudioSource backgroundSound;
    public float soundIncrement;


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
        //Player
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerLight = GameObject.FindGameObjectWithTag("PlayerLight").GetComponent<Light2D>();
        backgroundSound = GameObject.FindGameObjectWithTag("BackgroundSound").GetComponent<AudioSource>();

        //Death count
        //http://www.unity3d-france.com/unity/phpBB3/viewtopic.php?t=8741
        if (PlayerPrefs.GetInt("DeathNumber") != 0)
        {
            DeathNumber = PlayerPrefs.GetInt("DeathNumber");
            DeathCount.text = DeathNumber.ToString();
        }

        //Light intensity
        IntensityPourcentage(timer, playerLight.intensity);
        if (lightDecrement != 0)
        {
            StartCoroutine(Intensity());
        }

        //Sound Volume
        VolumePourcentage(timer, backgroundSound.volume);
        if (soundIncrement != 0)
        {
            StartCoroutine(Volume());
        }
    }

    //Kill Condition
    public void FixedUpdate()
    {
        if (playerLight.intensity <= 0f)
        {
            KillPlayer(player.gameObject);
        }
    }

    //Kill Player
    public void KillPlayer(GameObject player)
    {
        KillCount();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void KillCount()
    {
        DeathNumber++;
        PlayerPrefs.SetInt("DeathNumber", DeathNumber);
    }

    //Light Intensity
    private void IntensityPourcentage(float timer, float intensite)
    {
        lightDecrement = (intensite / timer);
    }

    private IEnumerator Intensity()
    {
        yield return new WaitForSeconds(1f);
        playerLight.intensity -= lightDecrement;

        if (playerLight.intensity > 0)
        {
            StartCoroutine(Intensity());
        }
    }

    //Sound Volume
    private void VolumePourcentage(float timer, float volume)
    {
        soundIncrement = (volume / timer);
        backgroundSound.volume = 0f;
    }

    private IEnumerator Volume()
    {
        yield return new WaitForSeconds(1f);
        backgroundSound.volume += soundIncrement;

        if (backgroundSound.volume < 1)
        {
            StartCoroutine(Volume());
        }
    }
}