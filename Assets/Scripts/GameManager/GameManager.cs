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
    private GameManager() { }
    public static GameManager Instance => _instance;

    [Header("Player")]
    private Player player;

    [Header("Kill")]
    public int DeathNumber;
    public TMP_Text DeathCount = null;

    [Header("Light")]
    private Light2D playerLight;
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
        //Player
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerLight = GameObject.FindGameObjectWithTag("PlayerLight").GetComponent<Light2D>();

        //Death count
        //http://www.unity3d-france.com/unity/phpBB3/viewtopic.php?t=8741
        if (PlayerPrefs.GetInt("DeathNumber") != 0)
        {
            DeathNumber = PlayerPrefs.GetInt("DeathNumber");
            DeathCount.text = DeathNumber.ToString();
        }

        //Light intensity
        intensity = playerLight.intensity;
        Pourcentage(timer, intensity);
        if (decrement != 0)
        {
            StartCoroutine(Intensity());
        }
    }
    public void FixedUpdate()
    {
        if (playerLight.intensity <= 0f)
        {
            KillPlayer(player.gameObject);
        }
    }

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
    private void Pourcentage(float timer, float intensite)
    {
        decrement = (intensite / timer);
    }
    private IEnumerator Intensity()
    {
        yield return new WaitForSeconds(1f);
        playerLight.intensity -= decrement;

        if (playerLight.intensity > 0)
        {
            StartCoroutine(Intensity());
        }
    }
}
