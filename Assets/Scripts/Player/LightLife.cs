using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class LightLife : MonoBehaviour
{
    public float timer;
    public float decrement;
    public float intensite;

    public Light2D Light2D;
    
    public GameObject player;

    public void Start()
    {
        intensite = Light2D.intensity;
        Pourcentage(timer,intensite);
        if (decrement != 0)
        {
            StartCoroutine(Intensite());
        }
    }

    public void FixedUpdate()
    {
        if(Light2D.intensity <= 0f)
        {
            GameManager.Instance.KillPlayer(player);
        }
    }


    public void Pourcentage(float timer,float intensite)
    {
        decrement = (intensite / timer);
    }




    private IEnumerator Intensite()
    {
        yield return new WaitForSeconds(1f);
        Light2D.intensity -= decrement;

        if(Light2D.intensity > 0)
        {
            StartCoroutine(Intensite());
        }
    }

}

